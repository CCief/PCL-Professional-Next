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

        // 已注入过 CheckBox 的 PageComp 实例（防重复注入）
        private static readonly System.Collections.Generic.HashSet<object> _injectedPages =
            new System.Collections.Generic.HashSet<object>();

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

        // 延迟定位用的静态传递（避免闭包类/TranslateTransform/Dispatcher 注入问题）
        private static object _pendingLoader, _pendingPan, _pendingCanvas;

        // Canvas.Loaded 事件处理器（方法组，无闭包）：布局完成后精确定位 checkbox 到加载器右侧同行
        private static void OnCanvasLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var canvas = sender as Panel;
                var lc = _pendingLoader as FrameworkElement;
                var pa = _pendingPan as FrameworkElement;
                // 注意：不清空静态字段——LayoutUpdated 持续校正还需要它们
                if (canvas == null || lc == null || pa == null || canvas.Children.Count == 0) return;
                var row = canvas.Children[0] as FrameworkElement;
                if (row == null) return;
                RepositionRow(row, lc, pa);
                // 持续校正：页面切换/布局变化后按钮不"飞走"
                row.LayoutUpdated -= OnRowLayoutUpdated;
                row.LayoutUpdated += OnRowLayoutUpdated;
            }
            catch { }
        }

        // 持续校正按钮位置（LayoutUpdated 高频触发，只在偏差 > 2px 时更新，避免布局循环）
        private static void OnRowLayoutUpdated(object sender, EventArgs e)
        {
            try
            {
                var row = sender as FrameworkElement;
                var lc = _pendingLoader as FrameworkElement;
                var pa = _pendingPan as FrameworkElement;
                if (row == null || lc == null || pa == null) return;
                RepositionRow(row, lc, pa);
            }
            catch { }
        }

        private static void RepositionRow(FrameworkElement row, FrameworkElement lc, FrameworkElement pa)
        {
            try
            {
                var pt = lc.TranslatePoint(new Point(0, 0), pa);
                double w = lc.ActualWidth > 10 ? lc.ActualWidth : 90;
                double targetLeft = pt.X + w + 7;    // 向左 4px
                double targetTop = pt.Y + 4;         // 向上 2px
                double curL = System.Windows.Controls.Canvas.GetLeft(row);
                double curT = System.Windows.Controls.Canvas.GetTop(row);
                if (double.IsNaN(curL) || Math.Abs(curL - targetLeft) > 2 || Math.Abs(curT - targetTop) > 2)
                {
                    System.Windows.Controls.Canvas.SetLeft(row, targetLeft);
                    System.Windows.Controls.Canvas.SetTop(row, targetTop);
                }
            }
            catch { }
        }

        // ---------- UI 注入：把 2 个 CheckBox 放到筛选条右上角（排序方式右侧、刷新按钮旁） ----------
        public static void SetupCheckBoxes(object pageObj)
        {
            try
            {
                var page = pageObj as PageComp;
                if (page == null) { DebugLog("page is null"); return; }

                // 用静态 HashSet 防重复（比视觉树遍历可靠，因为 row 可能被加到 Grid.Children 而非 panAlways.Children）
                if (_injectedPages.Contains(page)) return;
                _injectedPages.Add(page);

                var panAlways = GetProperty(page, "PanAlways") as StackPanel;
                if (panAlways == null) { DebugLog("PanAlways is null"); return; }

                // 一次性清理历史遗留的错误前缀文件（如 [工业时代2] xxx.jar → xxx.jar），
                // 只处理明确错误前缀，不影响 PCL Pro 正常命名的主下载文件
                CleanBadPrefixMods();

                // 两个 CheckBox 放进独立的水平 StackPanel（保证不重叠）
                var row = new StackPanel();
                row.Tag = "QuickDownloadHackRow";
                row.Orientation = Orientation.Horizontal;
                row.HorizontalAlignment = HorizontalAlignment.Left;
                row.Margin = new Thickness(10, 0, 0, 0);

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
                row.Children.Add(cbDeps);

                // 目标：排序方式下拉（ComboSearchSort）右侧同一行（= 筛选条右上角空白，紧挨刷新按钮）
                var sortCombo = GetProperty(page, "ComboSearchSort") as FrameworkElement;
                Panel target = null;
                if (sortCombo != null)
                {
                    target = GetParentPanel(sortCombo);
                    DebugLog("ComboSearchSort Parent=" + (target != null ? target.GetType().Name : "null"));
                }
                if (target == null)
                {
                    // 兜底：加载器不可用（如整合包页），插到 PanResults 之前（筛选条下方）
                    int idx = panAlways.Children.Count;
                    var panResults = GetProperty(page, "PanResults") as FrameworkElement;
                    if (panResults != null)
                    {
                        int i2 = panAlways.Children.IndexOf(panResults);
                        if (i2 >= 0) idx = i2;
                    }
                    panAlways.Children.Insert(idx, row);
                    DebugLog("fallback: injected before PanResults @ " + idx);
                    return;
                }

                if (target is Grid grid)
                {
                    // Canvas 插 panAlways 第 0 位（坐标系 = panAlways，绝对精确），
                    // Loaded 事件（方法组）延迟定位（布局完成后 TranslatePoint 才准确）；
                    // 关键1：Canvas 高度=0，不参与布局（否则高度依赖 checkbox 坐标 → loader 位置 →
                    //        panAlways 布局 → 循环依赖 → WPF 布局无限循环崩溃！）
                    // 关键2：IsHitTestVisible 保持默认 true（false 会禁用子树命中，checkbox 点不到）
                    // 关键3：SetZIndex 置顶 + Canvas 透明区域穿透，不挡下层卡片
                    var panAlways0 = GetProperty(page, "PanAlways") as StackPanel;
                    var loaderCombo = GetProperty(page, "ComboSearchLoader") as FrameworkElement;
                    if (panAlways0 != null && loaderCombo != null)
                    {
                        var canvas = new System.Windows.Controls.Canvas();
                        canvas.Tag = "QuickDownloadHackRow";
                        canvas.HorizontalAlignment = HorizontalAlignment.Left;
                        canvas.VerticalAlignment = VerticalAlignment.Top;
                        canvas.Height = 0;          // 关键：0 高度不参与布局，杜绝循环
                        canvas.Children.Add(row);
                        _pendingLoader = loaderCombo; _pendingPan = panAlways0; _pendingCanvas = canvas;
                        // 提升 z 序到最顶层（checkbox 在卡片之上，可点）
                        System.Windows.Controls.Panel.SetZIndex(canvas, 1000);
                        canvas.Loaded += OnCanvasLoaded;
                        panAlways0.Children.Insert(0, canvas);
                        DebugLog("canvas inserted at index 0, zero-height (no layout loop)");
                    }
                }
                else
                {
                    // StackPanel/WrapPanel 等：追加到末尾（若换行则插入到排序方式后面）
                    bool inserted = false;
                    if (sortCombo != null)
                    {
                        var items = target.Children;
                        int idx = items.IndexOf(sortCombo);
                        if (idx >= 0)
                        {
                            items.Insert(idx + 1, row);
                            inserted = true;
                        }
                    }
                    if (!inserted) target.Children.Add(row);
                    DebugLog("injected into " + target.GetType().Name + (inserted ? " after sort combo" : " (append)"));
                }
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
