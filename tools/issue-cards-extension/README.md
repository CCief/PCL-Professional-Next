# PCL Professional-Next · Issue 卡片入口（浏览器扩展）

在 `https://github.com/CCief/PCL-Professional-Next/issues` 这个**Issues 列表页**显示三张横向并排的淡彩卡片：

| 位置 | 卡片 | 背景 | 点击后 |
|---|---|---|---|
| 左 | 📫 新功能投稿栏 | 淡蓝 | 打开功能投稿表单 |
| 中 | 🎉 欢迎来到 PCL Professional-Next！ | 淡彩多色渐变 | 打开项目 README |
| 右 | 🐛 Bug 反馈栏 | 淡绿 | 打开 Bug 反馈表单 |

## 为什么需要扩展

GitHub 的 Issues 列表页不允许仓库自定义 HTML/CSS。仓库侧能做的只有「最多 3 个置顶 Issue」（已配置：`#2 / #3 / #4`），它们会横排显示在列表上方，但背景色是 GitHub 主题色，无法改成淡蓝 / 淡彩 / 淡绿。

本扩展只做两件事：

1. 在 Issues 列表页注入一排精确配色的卡片；
2. 隐藏 GitHub 原生的置顶卡片，避免同页出现两组卡片。

**不装扩展的访客**看到的是原生置顶卡片（标题、emoji、淡彩标签都在，只是背景为主题色）。

## 最快看到彩色版：一键启动（无需安装）

双击上一级的 `tools/Open-Issue-Cards.bat`：它会用 Microsoft Edge 单独起一个窗口，直接带上本扩展并打开 Issues 页，彩色卡片立刻出现。不会改动你现有的浏览器配置，关掉窗口即结束。

> 官方版 Google Chrome 从 137 起禁止用命令行加载未打包扩展（`--load-extension` 会被忽略），所以一键启动走 Edge；想在 **Chrome** 里长期生效，按下面装一次即可。

## 安装到 Chrome / Edge（一次装好，以后自动生效）

1. 打开 `chrome://extensions`（Edge 是 `edge://extensions`）。
2. 右上角打开「开发者模式」。
3. 点「加载已解压的扩展程序」，选择本文件夹 `tools/issue-cards-extension`。
4. 打开或刷新 `https://github.com/CCief/PCL-Professional-Next/issues`。

卸载或禁用扩展后页面立即恢复原样，仓库本身不受影响。

## 作用范围

- `matches` 只匹配 `https://github.com/CCief/PCL-Professional-Next/issues*`，其它网站和其它仓库完全不注入。
- 脚本进一步限定 `location.pathname` 必须正好是 `/CCief/PCL-Professional-Next/issues`，因此「新建 Issue」「Issue 详情页」不会出现卡片。
- 无网络请求、无权限申请、无外部资源；样式由 `cards.css` 提供，卡片内容在 `content.js` 里。
- GitHub 页面是 React/Turbo 动态渲染，DOM 会被重建，脚本用 `MutationObserver` 自动重新挂载。
