**HS2VR_POVcycle**

Full Character First-Person POV Mod for Honey Select 2 VR (BepInEx Plugin)

自由代入 Honey Select 2 VR 模式下所有角色第一视角的插件（BepInEx 插件）

**Introduction | 简介**

HS2VR_POVcycle 是一个适用于 Honey Select 2 VR 模式 的 BepInEx 插件，允许玩家在 VR 中：

✔ 一键进入第一人称视角模式（POV Mode）

✔ 自由代入场景中任意角色的头部视角（包括：男1 / 男2 / 女1 / 女2）

✔ 自动隐藏当前角色的头部模型（避免穿模）

✔ VR 控制、旋转、左右眼渲染保持原版正常

✔ 在代入每个角色时自动实时跟随头骨位置

整个插件从设计到完善，是我与ChatGPT协作开发的成果。

**Features | 功能**

1. X 键：开启 / 退出 VR 第一人称模式

进入 POV 模式后，视角将实时绑定到角色头部位置。

2. A 键：在所有角色之间切换视角

插件会自动扫描场景中的所有角色：

男角色 1（chaM_001）

男角色 2（chaM_002）

女角色 1（chaF_001）

女角色 2（chaF_002）

3. 自动隐藏当前 POV 目标的头部

避免在第一人称中看到自己的眼睛、脸、头发穿模。

4. 支持 VR 模式左右眼同步渲染

使用 VR Rig 而不是单眼摄像机，避免偏差问题。

5. 极简且高兼容性，不修改游戏文件

仅通过 BepInEx 注入，不改变游戏资产，风险极低。

**Controls | 操作方式**

按键（Quest/SteamVR）	功能

X（JoystickButton2）	开启/关闭 第一人称模式

A（JoystickButton0）	切换下一个角色 POV

按键适用于 SteamVR、Virtual Desktop、Quest Link 等运行方式。

**Installation | 安装方法**

确保你的 Honey Select 2 已安装 BepInEx 5.x

下载HS2VR_POVcycle.dll

放入：

游戏根目录/BepInEx/plugins/HS2VR_POVcycle.dll

启动HoneySelect2VR.exe运行游戏即可使用。

**Usage Tips | 使用提示**

在 POV 模式下，头部渲染会自动隐藏，只保留身体部分。

不建议在走路/剧烈动作中频繁切换 POV，以免产生 VR 眩晕。

如果某个角色头部高度不合适，可在源代码中调整：

private Vector3 povOffset = new Vector3(0f, 1.2f, 0.12f);

如果想修改键位 可直接在源码中替换键值：

X键 JoystickButton2

A键 JoystickButton0

**For Developers | 开发者说明**

本项目基于 BepInEx 5.x

使用 C# 和 Unity API

基于 HS2 DX R16 整合包测试

仅依赖 UnityEngine 和 BepInEx 框架，不含额外 DLL

源代码结构简单易懂，欢迎 PR / Issue

**License | 协议**

MIT License

自由使用、修改、分发。

请在分发时保留原作者署名。

**Credits | 致谢**

Crazy-Raven（b站：天生欠扁） — 开发者、项目发起人

ChatGPT — 代码生成

Illusion — 原游戏 Honey Select 2

BepInEx  — 插件运行框架

**Links | 链接**

Bilibili:
https://space.bilibili.com/3987430

GitHub Repo:
https://github.com/Crazy-Raven/HS2VR_POVcycle
