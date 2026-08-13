# PCL Pro-N

> Plain Craft Launcher 2 的"Pro-N"发行版 —— 由社区维护的开源启动器，在 PCL 基础上增强下载体验。

PCL Pro-N 是 [Plain Craft Launcher 2](https://github.com/Hex-Dragon/PCL2) 的增强发行版，核心目标是**让下载更简单**：快捷下载、自动安装前置模组、一键匹配版本与加载器。

当前版本：**v1.0.8-beta**

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

## 📜 许可证

本项目基于 GPL-3.0 开源。PCL 本体为 GPL-3.0 协议，衍生版本必须保持相同协议开源。

## 🙏 致谢

- [Hex-Dragon/PCL2](https://github.com/Hex-Dragon/PCL2) —— 原版 PCL，伟大的启动器
