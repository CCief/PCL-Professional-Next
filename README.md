# PCL Pro-N / PCL-Professional-Next

> 个人维护的逆向研究型发行版：在 PCL Pro（PCL 的「二改」）之上再做增强，也就是常说的**「二改的二改」**。

PCL Pro-N 是 [Plain Craft Launcher 2](https://github.com/Hex-Dragon/PCL2) 的一条远端衍生分支，核心目标是**让下载更简单**：快捷下载、自动安装前置模组、一键匹配版本与加载器。本仓库 `PCL-Professional-Next` 是它的源码仓库。

当前版本：**v0.1.0-alpha**（第一个预发行版）

## 🗂️ Issue 导航

[![📫 新功能投稿栏](docs/cards/feature.svg)](https://github.com/CCief/PCL-Professional-Next/issues/new?template=01-feature.yml) [![🎉 欢迎来到 PCL Professional-Next！](docs/cards/welcome.svg)](https://github.com/CCief/PCL-Professional-Next#readme) [![🐛 Bug 反馈栏](docs/cards/bug.svg)](https://github.com/CCief/PCL-Professional-Next/issues/new?template=02-bug.yml)

三张卡片从左到右分别是 **淡蓝 · 新功能投稿**、**淡彩 · 项目欢迎**、**淡绿 · Bug 反馈**。也可以打开 [卡片式 Issue 导航页](https://ccief.github.io/PCL-Professional-Next/) 查看横排大卡片视图；提交前建议先搜一下[已有 Issue](https://github.com/CCief/PCL-Professional-Next/issues?q=is%3Aissue)。

**Issues 列表页本身**：这三个入口已经做成置顶 Issue（#2 / #3 / #4），打开 [Issues](https://github.com/CCief/PCL-Professional-Next/issues) 就能在列表上方看到横排的三张卡片。GitHub 不允许仓库自定义该页的样式，所以置顶卡片的背景只能跟随 GitHub 主题色；淡蓝 / 淡彩 / 淡绿配色的完整卡片请看上面的卡片行或 [卡片式 Issue 导航页](https://ccief.github.io/PCL-Professional-Next/)。

## ⚠️ 项目定位：先把血统讲清楚

```
Hex-Dragon/PCL2            原版启动器（GPL-3.0）
  └─ PCL Pro               社区二次改编发行版（「二改」）
       └─ PCL Pro-N        本项目（「二改的二改」）
```

- **本项目不是 PCL 原版，也不是 PCL Pro 的官方版本**。它与 Hex-Dragon/PCL2 作者、以及任何 PCL Pro 的维护者之间，没有隶属、授权或合作关系；请不要把它当成上游的正式发行版。
- 本仓库的 C# 源码是**从 PCL Pro 的已发布产物反编译、并配合 BAML 资源重建**得到的，不是上游公开过的官方源码。仓库内保留 `libs/*.dll`、`resources/` 等来自发布产物的二进制，目的只是让这份重建源码能够被编译、验证和复现。
- 在还原出的基线上，本项目又叠加了一层自己的改动：快捷下载、自动前置、版本/加载器匹配、WPF 页面切换崩溃修复等。这一层才是「二改之上的再改」，与上游功能无关。
- 项目定位是**逆向学习、可复现构建与个人研究**。普通玩家请优先使用上游官方发行版。

## ✨ 特色功能

- **快捷下载**：搜索到模组后跳过详情页，直接开始下载
- **自动前置**：自动识别并下载模组的前置依赖（已修复 [工业时代2] 错误前缀问题）
- **版本/加载器匹配**：按已安装的 Minecraft 版本与加载器自动选择对应文件
- **CurseForge 直连**：绕过代理直连官方 API，搜索稳定可用
- **状态记忆**：快捷下载 / 自动前置开关状态自动保存

## 🚀 构建

环境要求：.NET 8 SDK（Windows）

```bash
dotnet build -c Release
```

产物位于 `bin/Release/net8.0-windows/`，主程序为 `Plain Craft Launcher 2.exe`。

> ⚠️ `AssemblyName` 保持为 `Plain Craft Launcher 2` 是刻意为之——WPF 的 BAML 资源 Uri 与其绑定，改动会导致资源加载失败。

### 发布自包含版（用户无需安装 .NET）

```bash
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true
```

## 📁 目录结构

```
├── PCL/                  # 核心逻辑（ModComp、ModDownload、FormMain 等）
├── controls/             # WPF 控件与页面
├── pages/                # 页面布局（.baml 编译资源）
├── libs/                 # 第三方依赖 dll（NAudio/Markdig/LiteDB/PCL.Core 等）
├── resources/            # 静态资源
└── PCL/QuickDownloadHack.cs  # 快捷下载/自动前置等增强功能实现
```

## 📦 发布流程

仓库内置 GitHub Actions：推送 `v*` 标签即自动构建并生成 Release。

```bash
git tag v1.1.0
git push origin v1.1.0
```

## 📜 许可证与第三方组件

- 上游 PCL2 采用 GPL-3.0，本仓库沿用 GPL-3.0（见 [LICENSE](LICENSE)）；衍生版本需保持相同协议开源。
- 需要明确的是：本仓库是**基于已发布产物的反编译重建**，上游从未发布过这份源码。若上游权利人认为本仓库内容不妥，可通过本仓库 Issue 联系维护者处理。
- `libs/` 下的 NAudio / Markdig / LiteDB / Newtonsoft.Json / PCL.Core / System.Text.Json 等 dll，以及 `resources/` 内的静态资源，版权归各自权利人所有；它们随仓库一同提供仅为便于构建，不代表本仓库拥有其著作权。
- 仓库**不含硬编码的 API Key**：CurseForge、NAID 等密钥一律从环境变量读取（`CURSEFORGE_API_KEY` / `NAID_CLIENT_SECRET`），请勿把密钥写进代码或提交记录。

## 🙏 致谢

- [Hex-Dragon/PCL2](https://github.com/Hex-Dragon/PCL2) —— 原版 PCL，伟大的启动器
