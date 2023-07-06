# ECharts.Net - 在.NET应用中使用ECharts
[![NuGet Badge](https://buildstats.info/nuget/ECharts.Net.Core?includePreReleases=true)](https://www.nuget.org/packages/ECharts.Net.Core/0.0.1)
<div align=center><img height='100' src=".github/icon.png"></div>

<br/>

<div align=center> 
  <font size='4'>
    <strong>简体中文</strong> | <a href='/README.en.md'>English</a>
  </font>
</div>

## 简介
可用于WPF/Winform的图表控件, 内部使用Webview2嵌入ECharts实现，基于最新的.net技术构建。

## 特点
- 现代化：基于最新的.net7以及Webview2构建
- 高性能：以尽可能低的额外开销实现与ECharts的互操作
- 类型安全：尽可能使用强类型封装ECharts组件
- 灵活性：在使用.net类型的同时也可以使用js直接操作

## 如何使用
使用Nuget包管理器安装：

| 平台 | 包名 |
| --- | --- |
| WinForm | [`ECharts.Net.Winform`](https://www.nuget.org/packages/ECharts.Net.Winform/) |
| WPF | [`ECharts.Net.Wpf`](https://www.nuget.org/packages/ECharts.Net.Wpf/) |
| WinUI3 | 尚未支持 |

由于处于早期开发阶段，目前没有文档。具体用法请参见本仓库中的Demo。

## 路线图
本项目目前处于前期开发阶段，已实现基本功能，理论上可以使用JS调用的方式实现全部官方例程。当前开发重点在于对`Option`的封装。

| 事项 | 状态 |
| --- | --- |
| 对Webview2控件的基本封装 | ✅ |
| 核心类型系统设计 | ✅ |
| **对`Option`进行封装** | 进行中 |
| WinUI3支持 | 计划中 |
| 序列化和互操作优化 | 计划中 |

## 截图
![screenshot](/.github/screenshot-wpf.png)

## 贡献
对本项目有任何疑问，欢迎[提交Issue](https://github.com/AZhrZho/ECharts.Net/issues/new)，或直接发起Pull Request
