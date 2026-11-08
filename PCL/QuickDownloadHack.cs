using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Reflection;
using System.Runtime.Serialization;

namespace PCL
{
    /// <summary>
    /// 快捷下载 + 下载前置 mod 功能。
    /// 由 il_patch 注入到 PCL 主 dll（类型移植），并 hook 两个点：
    ///  1) PageComp::PageCompControls_Inited 末尾 -> SetupCheckBoxes(page)
    ///  2) MyCompItem::MyCompItem_Click 开头 -> 检查快捷下载开关
    /// </summary>
    public static class QuickDownloadHack
    {
        private const string KEY_QUICK = "QuickDownloadEnabled";
        private const string KEY_DEPS = "QuickDownloadDeps";

        // ---------- 状态 ----------
        public static bool IsQuickDownload()
        {
            try { return Convert.ToBoolean(SetupGetValue(KEY_QUICK)); }
            catch { return false; }
        }

        public static bool IsDownloadDeps()
        {
            try { return Convert.ToBoolean(SetupGetValue(KEY_DEPS)); }
            catch { return false; }
        }

        // ---------- 状态（持久化到 PCL 配置目录 QuickDownloadHack.ini，避开 ConfigService 注册限制） ----------
        private const string STATE_FILE = "QuickDownloadHack.ini";

        private static object SetupGetValue(string key)
        {
            try
            {
                string val = ReadState(key);
                if (val == null) return null;
                return val == "1" ? (object)true : (object)false;
            }
            catch { return null; }
        }

        public static void SetSetupValue(string key, object val)
        {
            try
            {
                bool b = false;
                if (val is bool bb) b = bb;
                else b = Convert.ToBoolean(val);
                WriteState(key, b ? "1" : "0");
            }
            catch { }
        }

        private static string ReadState(string key)
        {
            try
            {
                string dir = PCL.ModBase.PathAppdataConfig;
                if (string.IsNullOrEmpty(dir)) return null;
                string path = System.IO.Path.Combine(dir, STATE_FILE);
                if (!System.IO.File.Exists(path)) return null;
                foreach (var line in System.IO.File.ReadAllLines(path))
                {
                    int eq = line.IndexOf('=');
                    if (eq > 0 && line.Substring(0, eq).Trim() == key)
                        return line.Substring(eq + 1).Trim();
                }
                return null;
            }
            catch { return null; }
        }

        private static void WriteState(string key, string val)
        {
            try
            {
                string dir = PCL.ModBase.PathAppdataConfig;
                if (string.IsNullOrEmpty(dir)) return;
                System.IO.Directory.CreateDirectory(dir);
                string path = System.IO.Path.Combine(dir, STATE_FILE);
                var lines = new List<string>();
                bool found = false;
                if (System.IO.File.Exists(path))
                {
                    foreach (var line in System.IO.File.ReadAllLines(path))
                    {
                        int eq = line.IndexOf('=');
                        if (eq > 0 && line.Substring(0, eq).Trim() == key)
                        { lines.Add(key + "=" + val); found = true; }
                        else lines.Add(line);
                    }
                }
                if (!found) lines.Add(key + "=" + val);
                System.IO.File.WriteAllLines(path, lines.ToArray());
            }
            catch { }
        }

        // 清理历史错误前缀文件（只跑一次）
        private static bool _prefixCleaned = false;

        private static void CleanBadPrefixMods()
        {
            if (_prefixCleaned) return;
            _prefixCleaned = true;
            try
            {
                string modsDir = GetModsFolder();
                if (modsDir == null) return;
                // 模式: [工业时代2] 原名.jar（前置下载被错误标成父项目中文名），
                // 只清理这个明确错误的前缀，不影响正常命名（如 [钠] sodium 主下载）
                string badPrefix = "[工业时代2] ";
                foreach (var f in System.IO.Directory.GetFiles(modsDir, "*.jar"))
                {
                    string name = System.IO.Path.GetFileName(f);
                    if (name.StartsWith(badPrefix))
                    {
                        string clean = name.Substring(badPrefix.Length);
                        if (!string.IsNullOrEmpty(clean) && clean.EndsWith(".jar", StringComparison.OrdinalIgnoreCase))
                        {
                            string newPath = System.IO.Path.Combine(modsDir, clean);
                            if (!System.IO.File.Exists(newPath))
                            {
                                try
                                {
                                    System.IO.File.Move(f, newPath);
                                    DebugLog("cleaned prefix: " + name + " -> " + clean);
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        // 每个分类页各自持有一组状态（object[]，见 MakeState）。不能用「最后一次注入」
        // 的全局单值：PageComp_IsVisibleChanged 每次切换分类都调 SetupCheckBoxes。
        // 刻意不带初始化器：portfix 只补字段定义、不移植 .cctor，运行版里初始为 null，
        // 所有取值必须走 GetStates() 惰性创建。
        private static object _stateList;

        // 只有「模组下载」页面（PageDownloadMod 里的 PageComp）才显示「下载前置mod」。
        // 整合包 / 资源包 / 光影 / 数据包 / 世界 / 实例管理页同样用 PageComp，
        // 但它们没有前置 mod 概念，勾选框不该出现在那里。
        // 主判定：ModMain.FrmDownloadMod.Content 与当前 PageComp 是同一实例；
        // 兜底：沿逻辑树向上能找到 PageDownloadMod 容器（框架字段尚未创建时）。
        private static bool IsModDownloadPage(object pageObj)
        {
            if (pageObj == null) return false;
            try
            {
                var f = typeof(ModMain).GetField("FrmDownloadMod",
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                var frm = f != null ? f.GetValue(null) : null;
                if (frm != null)
                {
                    var cp = frm.GetType().GetProperty("Content",
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    if (cp != null && ReferenceEquals(cp.GetValue(frm, null), pageObj)) return true;
                }
            }
            catch { }
            try
            {
                DependencyObject cur = pageObj as DependencyObject;
                for (int i = 0; i < 12 && cur != null; i++)
                {
                    cur = System.Windows.LogicalTreeHelper.GetParent(cur);
                    var fe = cur as FrameworkElement;
                    if (fe != null && fe.GetType().Name == "PageDownloadMod") return true;
                }
            }
            catch { }
            return false;
        }

        // 全部注入组（object[] of object[]）。惰性创建，不依赖 .cctor。
        private static object[] GetStates()
        {
            return _stateList as object[];
        }

        private static void AddState(object[] state)
        {
            var arr = GetStates();
            int n = arr == null ? 0 : arr.Length;
            var next = new object[n + 1];
            for (int i = 0; i < n; i++) next[i] = arr[i];
            next[n] = state;
            _stateList = next;
        }

        private static object[] FindState(object page)
        {
            var arr = GetStates();
            if (arr == null) return null;
            for (int i = 0; i < arr.Length; i++)
            {
                var s = arr[i] as object[];
                if (s != null && s.Length >= 6 && ReferenceEquals(s[4], page)) return s;
            }
            return null;
        }

        // state 布局（全用 BCL 类型，避免类型移植引入新类）：
        //  [0]=筛选条 MyCard(动画同步源)  [1]=PanAlways(插入容器)  [2]=保留(null，旧版 Canvas)
        //  [3]=下载前置mod               [4]=所属 PageComp        [5]=按钮行 StackPanel
        //  [6]=排序方式下拉(保留)        [7]=光影加载器(保留)     [8]=重置按钮(保留)
        // 方案 A：按钮行是 PanAlways 里的独立一行，由容器排版，不再需要 Canvas 定位、
        // 锚点回退、宿主边界夹紧与刷新按钮守卫 —— 物理上就不可能与筛选条控件重叠。
        private static object[] MakeState(object card, object panAlways, object unused,
                                          object deps, object page, object row, object sort,
                                          object shader, object reset)
        {
            return new object[] { card, panAlways, unused, deps, page, row, sort, shader, reset };
        }

        // 每组自己复核「下载前置mod」可见性 + 同步卡片动画；切换分类时再次调用，保证可逆。
        private static void SyncState(object[] state)
        {
            try
            {
                if (state == null || state.Length < 6) return;
                var deps = state[3] as FrameworkElement;
                if (deps != null)
                {
                    var want = IsModDownloadPage(state[4]) ? Visibility.Visible : Visibility.Collapsed;
                    if (deps.Visibility != want) deps.Visibility = want;
                }
                SyncCardAnimation(state);
            }
            catch { }
        }

        // 按钮行加载完成：复核本组可见性 + 同步一次动画
        private static void OnRowLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var row = sender as FrameworkElement;
                var state = row != null ? row.Tag as object[] : null;
                if (state != null) SyncState(state);
            }
            catch { }
        }

        // 布局变化：只同步动画，不重复做页面判定反射
        private static void OnRowLayoutUpdated(object sender, EventArgs e)
        {
            try
            {
                var row = sender as FrameworkElement;
                var state = row != null ? row.Tag as object[] : null;
                if (state != null) SyncCardAnimation(state);
            }
            catch { }
        }

        // 方案 A 的动画同步：MyPageRight.TriggerEnterAnimation 给每个 MyCard 单独设置
        // TranslateTransform 并错开 25ms 播放入场/退场动画。按钮行挂在 MyCard 外面
        // （PanAlways 独立一行），必须把同一个位移复制到 row，否则卡片滑入时按钮钉在原处，
        // 就是最初那个「按钮不随卡片一起移动」的 bug。
        // 只认 TranslateTransform；不依赖 IsLoaded/IsVisible，离屏布局测试也能覆盖。
        private static void SyncCardAnimation(object[] state)
        {
            try
            {
                if (state == null || state.Length < 6) return;
                var row = state[5] as FrameworkElement;
                var card = state[0] as FrameworkElement;
                if (row == null || card == null) return;
                double x = 0, y = 0;
                var src = card.RenderTransform as System.Windows.Media.TranslateTransform;
                if (src != null)
                {
                    x = src.X; y = src.Y;
                    if (double.IsNaN(x) || double.IsInfinity(x) ||
                        double.IsNaN(y) || double.IsInfinity(y)) return;
                }
                var ours = row.RenderTransform as System.Windows.Media.TranslateTransform;
                if (ours == null)
                {
                    row.RenderTransform = new System.Windows.Media.TranslateTransform(x, y);
                    return;
                }
                if (Math.Abs(ours.X - x) > 0.5 || Math.Abs(ours.Y - y) > 0.5)
                {
                    ours.X = x; ours.Y = y;
                }
            }
            catch { }
        }

        // ---------- UI 注入（方案 A）：筛选条卡片下方独立一行、右对齐 ----------
        public static void SetupCheckBoxes(object pageObj)
        {
            try
            {
                var page = pageObj as PageComp;
                if (page == null) return;

                // PageComp_IsVisibleChanged 每次切换分类都调进来；已注入页面不能 return，
                // 要复核可见性 + 动画同步。位置由布局容器决定，天然可逆。
                var existing = FindState(page);
                if (existing != null) { SyncState(existing); return; }

                var panAlways = GetProperty(page, "PanAlways") as StackPanel;
                if (panAlways == null) return;

                CleanBadPrefixMods();

                // 两个 CheckBox 放进水平 StackPanel：贴在筛选条卡片内部右下角，
                // 与「版本 / 加载器」同一行，右留 12px、下留 4px。
                // 不新增行、不新增卡片/背景，卡片原生白底直接承载。
                var row = new StackPanel();
                row.Orientation = Orientation.Horizontal;
                row.HorizontalAlignment = HorizontalAlignment.Right;
                row.VerticalAlignment = VerticalAlignment.Bottom;
                row.Margin = new Thickness(0, 0, 12, 4);

                var cbQuick = new MyCheckBox();
                cbQuick.Text = "快捷下载";
                cbQuick.Margin = new Thickness(0, 0, 0, 0);
                cbQuick.SetChecked(IsQuickDownload(), true);
                cbQuick.Change += OnQuickChange;
                row.Children.Add(cbQuick);

                var cbDeps = new MyCheckBox();
                cbDeps.Text = "下载前置mod";
                cbDeps.Margin = new Thickness(14, 0, 0, 0);
                cbDeps.SetChecked(IsDownloadDeps(), true);
                cbDeps.Change += OnDepsChange;
                cbDeps.Visibility = Visibility.Collapsed;   // 由 SyncState 按本组 page 决定
                row.Children.Add(cbDeps);

                // 找筛选条 MyCard（Grid 派生），把按钮行作为它的子项加进去。
                // MyCard 自身没有行列定义，所有子项默认铺满整个卡片；
                // 设右下对齐后，按钮正好落在第二行（版本 / 加载器）右侧的空白里，
                // 与筛选控件同一行、不新增行、不影响内容 Grid 的 7 列宽度分配。
                // 卡片整体 RenderTransform 的入场动画会自然带着按钮一起动，
                // 所以 state[0] 传 null 关闭额外的动画位移复制（否则会双倍）。
                var sortCombo = GetProperty(page, "ComboSearchSort") as FrameworkElement;
                var loaderCombo = GetProperty(page, "ComboSearchLoader") as FrameworkElement;
                var shaderCombo = GetProperty(page, "ComboSearchShaderLoader") as FrameworkElement;
                var resetBtn = GetProperty(page, "BtnSearchReset") as FrameworkElement;
                FrameworkElement card = FindHostCard(sortCombo) ?? FindHostCard(loaderCombo)
                                        ?? FindHostCard(shaderCombo) ?? FindHostCard(resetBtn);

                bool insideCard = false;
                var cardPanel = card as Panel;
                if (cardPanel != null)
                {
                    cardPanel.Children.Add(row);
                    insideCard = true;
                }
                else
                {
                    // 极端兜底（视觉树结构异常）：仍放进 PanAlways 的筛选条卡片之后，
                    // 不新增背景、不新增卡片；此时需要同步卡片入场位移。
                    int insertAt = -1;
                    var pr = GetProperty(page, "PanContent") as FrameworkElement
                             ?? GetProperty(page, "CardProjects") as FrameworkElement;
                    if (pr != null)
                    {
                        int k = panAlways.Children.IndexOf(pr);
                        if (k >= 0) insertAt = k;
                    }
                    if (insertAt < 0)
                    {
                        for (int k = 0; k < panAlways.Children.Count; k++)
                        {
                            var c = panAlways.Children[k] as FrameworkElement;
                            if (c != null && c.GetType().Name == "MyCard") { insertAt = k + 1; break; }
                        }
                    }
                    if (insertAt < 0) insertAt = 0;
                    if (insertAt > panAlways.Children.Count) insertAt = panAlways.Children.Count;
                    panAlways.Children.Insert(insertAt, row);
                }

                var state = MakeState(insideCard ? null : card, panAlways, null, cbDeps, page,
                                      row, sortCombo, shaderCombo, resetBtn);
                row.Tag = state;
                AddState(state);
                row.Loaded += OnRowLoaded;
                row.LayoutUpdated += OnRowLayoutUpdated;
                // 每个渲染帧同步卡片动画（RenderTransform 变化不触发布局）
                System.Windows.Media.CompositionTarget.Rendering -= OnRenderingReposition;
                System.Windows.Media.CompositionTarget.Rendering += OnRenderingReposition;
                SyncState(state);
            }
            catch (Exception ex) { DebugLog("SetupCheckBoxes FAILED: " + ex.GetType().Name + ": " + ex.Message); }
        }

        // 事件处理（不用 lambda，避免闭包类型注入问题）
        // 注意：Change 事件的 bool 是 user 参数（是否用户操作），不是勾选状态！
        // 必须从 sender.Checked 读真实状态。
        private static void OnQuickChange(object sender, bool user)
        {
            var cb = sender as MyCheckBox;
            bool val = cb != null && cb.Checked == true;
            DebugLog("OnQuickChange user=" + user + " checked=" + val);
            SetSetupValue(KEY_QUICK, val);
        }

        private static void OnDepsChange(object sender, bool user)
        {
            var cb = sender as MyCheckBox;
            bool val = cb != null && cb.Checked == true;
            DebugLog("OnDepsChange user=" + user + " checked=" + val);
            SetSetupValue(KEY_DEPS, val);
        }

        // 调试日志（正式版禁用，避免写盘开销）
        private static void DebugLog(string msg)
        {
            // 正式版：日志关闭
        }

        // 沿视觉树向上找筛选条所在的 MyCard（Grid 派生）。
        // 用类型名比对而不是 typeof(MyCard)，避免 helper 与主模块的类型引用差异。
        private static FrameworkElement FindHostCard(FrameworkElement fe)
        {
            try
            {
                DependencyObject cur = fe;
                for (int i = 0; i < 20 && cur != null; i++)
                {
                    cur = System.Windows.Media.VisualTreeHelper.GetParent(cur);
                    var f = cur as FrameworkElement;
                    if (f != null && f.GetType().Name == "MyCard") return f;
                }
            }
            catch { }
            return null;
        }

        // 找 descendant 在 parent.Children 里的直接子项索引。
        // 卡片可能嵌了好几层（MyCard -> Grid -> ...），不能直接 IndexOf(card)。
        private static int FindChildIndex(Panel parent, FrameworkElement descendant)
        {
            try
            {
                if (parent == null || descendant == null) return -1;
                DependencyObject cur = descendant;
                for (int i = 0; i < 24 && cur != null; i++)
                {
                    var p = System.Windows.Media.VisualTreeHelper.GetParent(cur);
                    if (ReferenceEquals(p, parent))
                    {
                        var fe = cur as FrameworkElement;
                        if (fe != null) return parent.Children.IndexOf(fe);
                    }
                    cur = p;
                }
            }
            catch { }
            return -1;
        }

        // 每帧同步：遍历所有注入组，只处理仍加载且可见的按钮行。
        // 不再依赖「最后一次注入」的全局单值，切回任意页面都能把动画位移算回来。
        private static void OnRenderingReposition(object sender, EventArgs e)
        {
            try
            {
                var arr = GetStates();
                if (arr == null) return;
                for (int i = 0; i < arr.Length; i++)
                {
                    var state = arr[i] as object[];
                    if (state == null || state.Length < 6) continue;
                    var row = state[5] as FrameworkElement;
                    if (row == null || !row.IsLoaded || !row.IsVisible) continue;
                    SyncCardAnimation(state);
                }
            }
            catch { }
        }

        private static Panel GetParentPanel(object child)
        {
            var fe = child as FrameworkElement;
            if (fe == null) return null;
            // 直接 Parent（一般是 ItemsPresenter/Border/TemplatedParent，不是 Panel）
            var p = fe.Parent as Panel;
            if (p != null) return p;
            // 向上遍历视觉树找第一个 Panel 容器（兼容 Grid/StackPanel/WrapPanel 等）
            DependencyObject cur = fe;
            for (int i = 0; i < 12 && cur != null; i++)
            {
                cur = System.Windows.Media.VisualTreeHelper.GetParent(cur);
                if (cur is Panel pp) return pp;
            }
            return null;
        }

        private static object GetProperty(object o, string prop)
        {
            var pi = o.GetType().GetProperty(prop,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (pi == null) return null;
            return pi.GetValue(o, null);
        }

        // ---------- 快捷下载：直接下载项目第一个可用文件 ----------
        public static void QuickDownload(object senderObj)
        {
            try
            {
                DebugLog("QuickDownload entered, quick=" + IsQuickDownload());
                var sender = senderObj as MyCompItem;
                if (sender == null) { DebugLog("  sender not MyCompItem"); return; }
                var project = sender.Tag as ModComp.CompProject;
                if (project == null) { DebugLog("  Tag not CompProject: " + (sender.Tag == null ? "null" : sender.Tag.GetType().Name)); return; }
                DebugLog("  project: " + (project.Id ?? "") + " curse=" + project.FromCurseForge + " type=" + project.Type);

                // CompFilesGet 会发网络请求，必须后台线程（PCL 拒绝 UI 线程网络）
                var proj = project;
                var t = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
                {
                    try
                    {
                        var files = ModComp.CompFilesGet(proj.Id, proj.FromCurseForge);
                        if (files == null || files.Count == 0) { DebugLog("  CompFilesGet returned empty"); return; }
                        DebugLog("  CompFilesGet ok, count=" + files.Count);
                        var file = PickFileForInstance(files, GetTargetLoader());
                        DebugLog("  downloading: " + (file?.DisplayName ?? "null"));
                        // 切回 UI 线程执行下载（Save_Click 操作 UI）
                        ModBase.RunInUi(delegate { DownloadFile(proj, file, 0); }, false);
                    }
                    catch (Exception ex) { DebugLog("  QuickDownload thread FAILED: " + ex.GetType().Name + ": " + ex.Message); }
                }));
                t.IsBackground = true;
                t.Start();
            }
            catch (Exception ex) { DebugLog("QuickDownload FAILED: " + ex.GetType().Name + ": " + ex.Message); }
        }

        // 目标加载器：优先下载页筛选器（用户选 Fabric/Forge/NeoForge），其次实例加载器
        private static ModComp.CompLoaderType GetTargetLoader()
        {
            try
            {
                var frmMod = typeof(ModMain).GetField("FrmDownloadMod",
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                var frm = frmMod != null ? frmMod.GetValue(null) : null;
                if (frm != null)
                {
                    var contentProp = frm.GetType().GetProperty("Content",
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                    var pageComp = contentProp != null ? contentProp.GetValue(frm, null) : null;
                    if (pageComp != null)
                    {
                        var comboProp = pageComp.GetType().GetProperty("ComboSearchLoader",
                            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                        var combo = comboProp != null ? comboProp.GetValue(pageComp, null) : null;
                        if (combo != null)
                        {
                            var selProp = combo.GetType().GetProperty("SelectedItem",
                                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                            var sel = selProp != null ? selProp.GetValue(combo, null) : null;
                            if (sel is ModComp.CompLoaderType)
                            {
                                DebugLog("  filter loader: " + sel);
                                return (ModComp.CompLoaderType)sel;
                            }
                        }
                    }
                }
            }
            catch { }
            // 兜底：实例加载器
            var inst = GetCurrentInstance();
            var ld = GetInstanceLoader(GetInstanceVersion(inst));
            DebugLog("  instance loader: " + ld);
            return ld;
        }

        // 按（版本 + 加载器）匹配 CompFile；找不到则回退 files[0]
        private static ModComp.CompFile PickFileForInstance(List<ModComp.CompFile> files, ModComp.CompLoaderType loader)
        {
            try
            {
                if (files == null || files.Count == 0) return null;
                var inst = GetCurrentInstance();
                if (inst == null) { DebugLog("  McInstanceCurrent null, using files[0]"); return files[0]; }
                var verInfo = GetInstanceVersion(inst);
                string targetVer = GetMcName(verInfo);
                if (string.IsNullOrEmpty(targetVer)) { DebugLog("  targetVer empty, using files[0]"); return files[0]; }

                // 未从筛选器拿到加载器时用实例加载器
                if (loader == ModComp.CompLoaderType.Any)
                    loader = GetInstanceLoader(verInfo);

                DebugLog("  targetVer=" + targetVer + " loader=" + loader);

                // 1) 版本精确匹配 + 加载器匹配（显式循环，不用 lambda 避免注入问题）
                for (int i = 0; i < files.Count; i++)
                {
                    var f = files[i];
                    if (f.GameVersions != null && f.GameVersions.Contains(targetVer))
                    {
                        if (loader == ModComp.CompLoaderType.Any || f.ModLoaders == null || f.ModLoaders.Contains(loader))
                            return f;
                    }
                }
                // 2) 版本匹配 + 加载器"兼容"（ModLoaders 为空=通用版优先；其次不含明确冲突加载器的）
                //    避免直接取第一个而拿到其他加载器的版本（如选 Fabric 却下 NeoForge）
                for (int i = 0; i < files.Count; i++)
                {
                    var f = files[i];
                    if (f.GameVersions != null && f.GameVersions.Contains(targetVer))
                    {
                        if (f.ModLoaders == null || f.ModLoaders.Count == 0)
                            return f;
                    }
                }
                for (int i = 0; i < files.Count; i++)
                {
                    var f = files[i];
                    if (f.GameVersions != null && f.GameVersions.Contains(targetVer))
                    {
                        if (f.ModLoaders != null && f.ModLoaders.Contains(loader))
                            return f;
                    }
                }
                // 2b) 仅版本匹配（万不得已）
                for (int i = 0; i < files.Count; i++)
                {
                    var f = files[i];
                    if (f.GameVersions != null && f.GameVersions.Contains(targetVer))
                        return f;
                }
                // 3) 回退
                DebugLog("  no version match for " + targetVer + ", fallback files[0]");
                return files[0];
            }
            catch (Exception ex) { DebugLog("  PickFileForInstance FAILED: " + ex.Message); return files != null && files.Count > 0 ? files[0] : null; }
        }

        // ---- 当前实例辅助 ----
        private static object GetCurrentInstance()
        {
            try
            {
                var curProp = typeof(ModMinecraft).GetProperty("McInstanceCurrent",
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                if (curProp == null) return null;
                return curProp.GetValue(null, null);
            }
            catch { return null; }
        }

        private static object GetInstanceVersion(object inst)
        {
            try
            {
                if (inst == null) return null;
                var verProp = inst.GetType().GetProperty("Version",
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                return verProp != null ? verProp.GetValue(inst, null) : null;
            }
            catch { return null; }
        }

        private static string GetMcName(object verInfo)
        {
            try
            {
                if (verInfo == null) return null;
                var f = verInfo.GetType().GetField("McName",
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                return f != null ? (string)f.GetValue(verInfo) : null;
            }
            catch { return null; }
        }

        private static ModComp.CompLoaderType GetInstanceLoader(object verInfo)
        {
            try
            {
                if (verInfo == null) return ModComp.CompLoaderType.Any;
                if (GetBoolField(verInfo, "HasFabric")) return ModComp.CompLoaderType.Fabric;
                if (GetBoolField(verInfo, "HasForge")) return ModComp.CompLoaderType.Forge;
                if (GetBoolField(verInfo, "HasNeoForge")) return ModComp.CompLoaderType.NeoForge;
                if (GetBoolField(verInfo, "HasQuilt")) return ModComp.CompLoaderType.Quilt;
                if (GetBoolField(verInfo, "HasLabyMod")) return ModComp.CompLoaderType.LabyMod;
                return ModComp.CompLoaderType.Any;
            }
            catch { return ModComp.CompLoaderType.Any; }
        }

        // 当前实例的 mods 目录（不存在返回 null）
        private static string GetModsFolder()
        {
            try
            {
                var inst = GetCurrentInstance();
                var verInfo = GetInstanceVersion(inst);
                string verName = GetMcName(verInfo);
                if (string.IsNullOrEmpty(verName)) return null;
                string dir = System.IO.Path.Combine(PCL.ModMinecraft.PathMcFolder, "versions", verName, "mods");
                return System.IO.Directory.Exists(dir) ? dir : null;
            }
            catch { return null; }
        }

        // 判断某依赖文件是否已存在于 mods 目录（按文件名去扩展名前缀匹配，避免重复下载）
        private static bool IsFileInstalled(ModComp.CompFile f)
        {
            try
            {
                if (f == null) return false;
                string modsDir = GetModsFolder();
                if (modsDir == null) return false;
                string fn = f.FileName != null ? f.FileName : (f.DisplayName != null ? f.DisplayName : null);
                if (string.IsNullOrEmpty(fn)) return false;
                // 去扩展名
                int dot = fn.LastIndexOf('.');
                string baseName = dot > 0 ? fn.Substring(0, dot) : fn;
                foreach (var existing in System.IO.Directory.GetFiles(modsDir, "*.jar"))
                {
                    string en = System.IO.Path.GetFileNameWithoutExtension(existing);
                    if (en.StartsWith(baseName, StringComparison.OrdinalIgnoreCase) || baseName.StartsWith(en, StringComparison.OrdinalIgnoreCase))
                        return true;
                }
                return false;
            }
            catch { return false; }
        }

        private static bool GetBoolField(object o, string name)
        {
            try
            {
                var f = o.GetType().GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (f == null) return false;
                return (bool)f.GetValue(o);
            }
            catch { return false; }
        }

        /// <summary>
        /// 下载单个文件（depth 防止依赖递归过深）
        /// 用 PCL 原生 Save_Click（Mod 下载完整流程，内部 RunInNewThread 后台下载到 mods 文件夹）
        /// 关键：用全局单例 FrmDownloadCompDetail（new 实例缺初始化状态会 NRE）
        /// </summary>
        public static void DownloadFile(ModComp.CompProject project, ModComp.CompFile file, int depth)
        {
            if (depth > 5) return;
            try
            {
                var detailType = typeof(PageDownloadCompDetail);
                var saveClick = detailType.GetMethod("Save_Click",
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (saveClick == null) { DebugLog("  Save_Click method not found"); return; }

                // 优先用全局单例（已完整初始化）
                var detail = GetFrmDownloadCompDetail();
                if (detail == null) { DebugLog("  FrmDownloadCompDetail is null"); return; }

                var projField = detailType.GetField("Project",
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (projField != null) projField.SetValue(detail, project);
                else DebugLog("  Project field not found");

                var item = new MyListItem();
                item.Tag = file;
                DebugLog("  invoking Save_Click (PCL 原生下载)...");
                try
                {
                    saveClick.Invoke(detail, new object[] { item, null });
                    DebugLog("  Save_Click invoked OK");
                }
                catch (Exception ex)
                {
                    var inner = ex.InnerException;
                    string detail2 = inner != null ? (inner.GetType().Name + ": " + inner.Message) : ex.Message;
                    DebugLog("  Save_Click THREW: " + detail2);
                    throw;
                }

                // 前置下载（depth>0）：PCL 保存文件名会用父项目的中文名前缀（如 [工业时代2] xxx.jar），
                // 这是错误命名。下载完成后把文件重命名为 [自身显示名] 文件名，消除父项目前缀。
                if (depth > 0 && file != null && !string.IsNullOrEmpty(file.FileName))
                {
                    var f2 = file;
                    var rt = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
                    {
                        try
                        {
                            string modsDir = GetModsFolder();
                            if (modsDir == null) return;
                            string found = null;
                            for (int i = 0; i < 90; i++)   // 轮询最多 90 秒等下载完成
                            {
                                System.Threading.Thread.Sleep(1000);
                                try
                                {
                                    var cands = System.IO.Directory.GetFiles(modsDir, "*" + f2.FileName);
                                    if (cands != null && cands.Length > 0) { found = cands[0]; break; }
                                }
                                catch { }
                            }
                            if (found == null) return;
                            // 直接用 Modrinth 原文件名（去掉 PCL Pro 错误加的 [父中文名] 前缀），
                            // 不依赖 DisplayName（它可能也被污染成父项目中文名）
                            string newName = f2.FileName;
                            string newPath = System.IO.Path.Combine(modsDir, newName);
                            if (string.Equals(found, newPath, StringComparison.OrdinalIgnoreCase)) return;
                            for (int i = 0; i < 10; i++)   // 等文件解锁后重命名
                            {
                                try
                                {
                                    System.IO.File.Move(found, newPath, true);
                                    DebugLog("  renamed dep file: " + System.IO.Path.GetFileName(found) + " -> " + newName);
                                    return;
                                }
                                catch { System.Threading.Thread.Sleep(1000); }
                            }
                        }
                        catch { }
                    }));
                    rt.IsBackground = true;
                    rt.Start();
                }

                // 依赖下载：确认对话框
                DebugLog("  deps check: IsDownloadDeps=" + IsDownloadDeps() + " raw=" + (file.RawDependencies == null ? "null" : "count=" + file.RawDependencies.Count));
                if (IsDownloadDeps() && file.RawDependencies != null && file.RawDependencies.Count > 0)
                {
                    DebugLog("  deps detected: " + file.RawDependencies.Count);
                    AskAndDownloadDeps(project, file.RawDependencies, depth);
                }
                else
                {
                    DebugLog("  no deps to download");
                }
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException;
                string m = inner != null ? (inner.GetType().Name + ": " + inner.Message) : ex.Message;
                DebugLog("DownloadFile FAILED: " + ex.GetType().Name + ": " + m);
            }
        }

        // 获取 PCL 全局详情页单例（ModMain.FrmDownloadCompDetail）
        // 若未创建（用户没进过详情页），用 FormatterServices 跳过 ctor 创建（Save_Click 只依赖 Project 字段，
        // 不需要完整 UI 初始化；ctor 的 InitializeComponent 在无 UI 上下文时会 NRE）
        private static PageDownloadCompDetail GetFrmDownloadCompDetail()
        {
            try
            {
                var f = typeof(ModMain).GetField("FrmDownloadCompDetail",
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                if (f == null) { DebugLog("  FrmDownloadCompDetail field not found"); return null; }
                var d = f.GetValue(null) as PageDownloadCompDetail;
                if (d != null) return d;

                DebugLog("  FrmDownloadCompDetail null, creating via GetUninitializedObject...");
                d = (PageDownloadCompDetail)FormatterServices.GetUninitializedObject(typeof(PageDownloadCompDetail));
                // 写回静态字段（PCL 后续也用这个实例）
                f.SetValue(null, d);
                DebugLog("  created + cached FrmDownloadCompDetail");
                return d;
            }
            catch (Exception ex) { DebugLog("  GetFrmDownloadCompDetail FAILED: " + ex.Message); return null; }
        }

        // 依赖下载：自动下载（不弹确认框）。"前提是没有"——已安装的依赖跳过
        private static void AskAndDownloadDeps(ModComp.CompProject parent, List<string> depIds, int depth)
        {
            try
            {
                if (depIds == null || depIds.Count == 0) return;
                DebugLog("  deps auto-download: " + depIds.Count + " deps");
                SafeDownloadDeps(parent, depIds, depth);
            }
            catch (Exception ex) { DebugLog("AskAndDownloadDeps FAILED: " + ex.GetType().Name + ": " + ex.Message); }
        }

        // 确认框"下载"回调的保险壳：异常绝不外泄（防线程崩溃）
        private static void SafeDownloadDeps(ModComp.CompProject parent, List<string> depIds, int depth)
        {
            try
            {
                DownloadDependencies(parent, depIds, depth);
            }
            catch (Exception ex) { DebugLog("SafeDownloadDeps FAILED: " + ex.GetType().Name + ": " + ex.Message); }
        }

        private static void DownloadDependencies(ModComp.CompProject parent, List<string> depIds, int depth)
        {
            if (depIds == null || depIds.Count == 0) return;
            // CompFilesGet 发网络请求，需后台线程；外层 try-catch 防线程异常崩溃
            var t = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
            {
                try
                {
                    foreach (var depId in depIds)
                    {
                        try
                        {
                            var files = ModComp.CompFilesGet(depId, parent.FromCurseForge);
                            if (files == null || files.Count == 0) continue;
                            var f = PickFileForInstance(files, GetTargetLoader());
                            // "前提是没有"：已安装的同名文件跳过
                            if (f != null && IsFileInstalled(f))
                            {
                                DebugLog("  dep " + depId + " already installed, skip");
                                continue;
                            }
                            // 反射构造依赖项目的 CompProject（跳过 JObject ctor）
                            var depProject = CreateProject(depId, parent.FromCurseForge, parent.Type, f != null ? f.DisplayName : depId);
                            ModBase.RunInUi(delegate { DownloadFile(depProject, f, depth + 1); }, false);
                        }
                        catch (Exception ex) { DebugLog("DownloadDependencies dep " + depId + " FAILED: " + ex.GetType().Name + ": " + ex.Message); }
                    }
                }
                catch (Exception ex) { DebugLog("DownloadDependencies thread FAILED: " + ex.GetType().Name + ": " + ex.Message); }
            }));
            t.IsBackground = true;
            t.Start();
        }

        private static ModComp.CompProject CreateProject(string id, bool fromCurseForge, ModComp.CompType type, string name)
        {
            var t = typeof(ModComp.CompProject);
            var p = (ModComp.CompProject)FormatterServices.GetUninitializedObject(t);
            SetField(p, "Id", id);
            SetField(p, "FromCurseForge", fromCurseForge);
            SetField(p, "Type", type);
            SetField(p, "RawName", name ?? id);
            // Save_Click 后台线程会读 ModLoaders（空列表即可，不能 null → NRE 崩溃）
            SetField(p, "ModLoaders", new List<ModComp.CompLoaderType>());
            return p;
        }


        // PCL 兼容补丁：Mod 下载页初始化会枚举 .minecraftersions，目录不存在则崩。
        // 由 PageDownloadInstall::Init 开头调用，先确保目录存在（自带 try-catch，绝不外抛）。
        public static void EnsureMcFolder()
        {
            try
            {
                string root = PCL.ModMinecraft.PathMcFolder;
                if (!string.IsNullOrEmpty(root))
                    System.IO.Directory.CreateDirectory(System.IO.Path.Combine(root, "versions"));
            }
            catch { }
            EnsureCurseForgeKey();
        }

        // CurseForge 修复：强制 SystemCfApiType=0（直连官方 API + 内置官方 key，实测 200 有效）。
        // 根因：PCL Pro 默认把 CurseForge 请求转发到自建代理 pclpro.mtr.qzz.io（UseCfProxy=true），
        //       代理失效 → 静默返回空 → "搜索无结果"。type=0 时 UseCfProxy=false → 直连 + x-api-key。
        private static void EnsureCurseForgeKey()
        {
            try
            {
                // ① 强制走官方直连（不走 pclpro 代理 / mcimirror 镜像）
                var setup = PCL.ModBase.Setup;
                if (setup != null)
                {
                    setup.Set("SystemCfApiType", 0);
                    DebugLog("SystemCfApiType forced to 0 (direct CurseForge API)");
                }
                // ② 保底：环境变量 key 写入 CurseForgeAPIKey 字段（type=1 分支用得上）
                string key = System.Environment.GetEnvironmentVariable("PCL_CURSEFORGE_API_KEY");
                if (string.IsNullOrEmpty(key)) return;
                var t = typeof(PCL.ModBase).Assembly.GetType("PCL.ModSecret");
                if (t == null) return;
                var f = t.GetField("CurseForgeAPIKey",
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
                if (f != null)
                {
                    f.SetValue(null, key);
                    DebugLog("CurseForgeAPIKey set (length " + key.Length + ")");
                }
            }
            catch { }
        }

        private static void SetField(object o, string name, object val)
        {
            var t = o.GetType();
            var f = t.GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (f != null) f.SetValue(o, val);
        }
    }
}
