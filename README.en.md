# ECharts.Net - Bring ECharts into .NET applications

<br/>

<div align=center><img height='100' src=".github/icon.png"></div>

<br/>

<div align=center> 
  <font size='4'>
    <a href='/README.md'>简体中文</a> | <strong>English</strong>
  </font>
</div>

## Introduction
ECharts.Net include control and types for WPF/Winform, which enables you to draw awsome charts using ECharts and interact with. Implemented using Microsoft Edge Webview2, based on modern .NET technologies.

## Features
- Modern：based on newest .NET7 framework and Webview2
- Performance：Implement with the lowest possible additional overhead
- Type safety: Use strongly typed encapsulation ECharts components whenever possible
- Flexibility: You can also use JavaScript to manipulate componets directly while using .NET api

## Usage
Install using the Nuget package manager：

| Platform | Package name |
| --- | --- |
| WinForm | [`ECharts.Net.Winform`](https://www.nuget.org/packages/ECharts.Net.Winform/) |
| WPF | [`ECharts.Net.Wpf`](https://www.nuget.org/packages/ECharts.Net.Wpf/) |
| WinUI3 | Currently not supported |

Since we are in the early stages of development, there is currently no documentation. For specific usage, please refer to the demo project in this repository.

## Roadmap
This project is currently in the early stages of development, while the basic functions have been implemented, and all official routines can theoretically be implemented using direct JS calls. We are now focus on encapsulating `Option` type.

| Matters | State |
| --- | --- |
| Basic encapsulation of Webview2 controls | ✅ |
| Core design | ✅ |
| **Encapsulation of `Option` type** | In progress |
| Support for WinUI3 | Scheduled |
| Serialization and interoperability optimizations | Scheduled |

## Screenshot
![screenshot](/.github/screenshot-wpf.png)

## Contributing
Any [Issues](https://github.com/AZhrZho/ECharts.Net/issues/new) or PRs related to this project were welcomed.
