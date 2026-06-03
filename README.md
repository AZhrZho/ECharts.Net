# ECharts.Net - 在.NET应用中使用ECharts
[![NuGet Badge](https://buildstats.info/nuget/ECharts.Net.Core?includePreReleases=true)](https://www.nuget.org/packages/ECharts.Net.Core/0.0.4)
<div align=center><img height='100' src=".github/icon.png"></div>

<br/>

<div align=center>
  <font size='4'>
    <strong>简体中文</strong> | <a href='/README.en.md'>English</a>
  </font>
</div>

## 路线图
本项目目前处于前期开发阶段，已实现基本功能，理论上可以使用JS调用的方式实现全部官方例程。当前开发重点在于对`Option`的封装。

| 事项 | 状态 |
| --- | --- |
| 对Webview2控件的基本封装 | ✅ |
| 核心类型系统设计 | ✅ |
| **对`Option`进行封装** | 进行中 |
| WinUI3支持 | 计划中 |
| 序列化和互操作优化 | 计划中 |
| .Net Framework支持 | ✅ |

---

## 目录
- [简介](#简介)
- [如何使用](#如何使用)
  - [快速开始](#快速开始)
  - [属性详解](#属性详解)
  - [实时数据更新](#实时数据更新)
  - [属性速查](#属性速查)
  - [EChartsReady 事件与 EChart 实例](#echartsready-事件与-echart-实例)
- [截图](#截图)
- [贡献](#贡献)

---

## 简介
可用于WPF/Winform的图表控件, 内部使用Webview2嵌入ECharts实现，基于最新的.net技术构建，同时兼容.net framework。

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

由于处于早期开发阶段，目前没有完整文档。具体用法请参见本仓库中的Demo。

### 快速开始

#### WPF

**XAML 声明：**
```xml
xmlns:echarts="clr-namespace:ECharts.Net.Wpf;assembly=ECharts.Net.Wpf"

<echarts:EChartsView x:Name="chart" />
```

**数据绑定（推荐）：**
```xml
<echarts:EChartsView DepOption="{Binding ChartOption}"
                      Loading="{Binding IsLoading}" />
```

```csharp
// ViewModel 中，属性变更后图表自动刷新（内置 16ms 防抖）
public Option? ChartOption
{
    get => _chartOption;
    set => SetProperty(ref _chartOption, value);
}
```

**代码设置：**
```csharp
var option = new Option
{
    XAxis = new XAxis { Type = AxisType.Category, Data = new[] { "A", "B", "C" } },
    YAxis = new YAxis { Type = AxisType.Value },
    Series = new Series[] { new LineSeries { Data = new double[] { 10, 20, 30 } } }
};

// WPF：通过依赖属性设置
chart.DepOption = option;

// WinForm：直接赋值
chart.ChartOption = option;
```

### 属性详解

#### DepOption / ChartOption — 图表配置（强类型）

通过 `Option` 对象配置图表，支持智能提示和编译时检查。

```csharp
var option = new Option
{
    Title = new Title { Text = "图表标题" },
    Tooltip = new() { Trigger = TooltipTrigger.Axis },
    Legend = new Legend { Data = new LegendData[] { "系列A", "系列B" } },
    XAxis = new XAxis
    {
        Type = AxisType.Category,
        Data = new[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" }
    },
    YAxis = new YAxis { Type = AxisType.Value },
    Series = new Series[]
    {
        new LineSeries { Data = new double[] { 150, 230, 224, 218, 135, 260 } }
    }
};
```

**WPF 绑定：** 属性名是 `DepOption`，支持 XAML 数据绑定
```xml
<echarts:EChartsView DepOption="{Binding ChartOption}" />
```

**WinForm：** 属性名是 `ChartOption`，直接赋值
```csharp
chart.ChartOption = option;
```

> WPF 绑定模式下，属性值变更会自动刷新图表，内置 16ms 防抖避免频繁更新。

#### DepOptionInJs / ChartOptionInJs — 图表配置（JSON 字符串）

当强类型 API 尚未封装某些 ECharts 功能时，可直接传入 ECharts 原生 JSON 配置，拥有完整的功能访问能力。

```csharp
var optionJs = """
    {
        "title": { "text": "JS配置" },
        "xAxis": { "type": "category", "data": ["A", "B", "C"] },
        "yAxis": { "type": "value" },
        "series": [{ "type": "line", "data": [10, 20, 30] }]
    }
    """;

// WPF
chart.DepOptionInJs = optionJs;

// WinForm
chart.ChartOptionInJs = optionJs;
```

**WPF 绑定：**
```xml
<echarts:EChartsView DepOptionInJs="{Binding ChartOptionInJs}" />
```

> `DepOption` 和 `DepOptionInJs` 同时设置时，`DepOption` 优先。

#### Loading — 加载动画

控制图表加载遮罩的显示与隐藏，适合在数据加载期间使用。

```csharp
// 显示加载动画
chart.Loading = true;

// 数据加载完成后隐藏
chart.Loading = false;
```

**WPF 绑定：**
```xml
<echarts:EChartsView Loading="{Binding IsLoading}" />
```

#### NotMerge — 配置合并模式

控制 `setOption` 时是否与已有配置合并。默认 `false`（合并），设为 `true` 时完全替换。

```csharp
// 默认行为：新配置与旧配置合并
chart.NotMerge = false;

// 完全替换旧配置
chart.NotMerge = true;
```

**WPF 绑定：**
```xml
<echarts:EChartsView DepOption="{Binding ChartOption}" NotMerge="True" />
```

#### LazyUpdate — 延迟更新

设为 `true` 时，`setOption` 不会立即渲染，而是在下次动画帧时统一更新，适合高频数据更新场景。

```csharp
chart.LazyUpdate = true;
```

**WPF 绑定：**
```xml
<echarts:EChartsView DepOption="{Binding ChartOption}" LazyUpdate="True" />
```

#### ContainerHtml — 自定义容器 HTML

替代内置的 HTML 模板，用于自定义页面结构（如添加额外 CSS、修改背景色等）。设置后内部会自动注入 ECharts 引擎脚本并初始化图表实例。

> **注意：** 必须在控件初始化之前设置（即 `EChartsReady` 事件触发前），且 HTML 中必须包含一个作为图表容器的 `<div>`。

**WPF (XAML)：**
```xml
<echarts:EChartsView ContainerHtml="{Binding MyHtml}"
                      ContainerElementId="chart1" />
```

**WPF (代码)：**
```csharp
var chart = new EChartsView();
chart.ContainerHtml = """
    <!DOCTYPE html>
    <html>
    <head>
        <style>
            body { background: #1a1a2e; }
            #chart1 { width: 100%; height: 100%; }
        </style>
    </head>
    <body>
        <div id="chart1"></div>
    </body>
    </html>
    """;
chart.ContainerElementId = "chart1";
```

**WinForm：**
```csharp
var chart = new EChartsControl();
chart.ContainerHtml = """
    <!DOCTYPE html>
    <html>
    <head>
        <style>
            body { background: #1a1a2e; }
            #chart1 { width: 100%; height: 100%; }
        </style>
    </head>
    <body>
        <div id="chart1"></div>
    </body>
    </html>
    """;
chart.ContainerElementId = "chart1";
```

#### ContainerElementId — 图表容器元素 ID

配合 `ContainerHtml` 使用，指定自定义 HTML 中图表 `<div>` 的 `id`。不设置时默认为 `"root"`。

#### IsDark — 深色主题

控制图表是否使用 ECharts 深色主题（Dark）。默认 `false`（浅色），设为 `true` 时图表将以深色主题渲染。

> **注意：** 必须在控件初始化之前设置（即 `EChartsReady` 事件触发前），主题在初始化时确定，运行时更改会重新初始化图表。

```csharp
// 启用深色主题
chart.IsDark = true;
```

**WPF 绑定：**
```xml
<echarts:EChartsView IsDark="True" DepOption="{Binding ChartOption}" />
```

**WinForm：**
```csharp
var chart = new EChartsControl();
chart.IsDark = true;
```

### 实时数据更新

WPF 绑定模式下，只需更新 ViewModel 属性，图表自动刷新：

```csharp
// ViewModel
private DispatcherTimer _timer;
private readonly List<string> _times = new();
private readonly List<double> _values = new();

private void OnTimerTick()
{
    _times.Add(DateTime.Now.ToString("HH:mm:ss"));
    _values.Add(Random.Shared.Next(50, 200));
    if (_times.Count > 20) { _times.RemoveAt(0); _values.RemoveAt(0); }

    // 更新属性，图表自动刷新
    ChartOption = new Option
    {
        XAxis = new XAxis { Type = AxisType.Category, Data = new List<string>(_times) },
        YAxis = new YAxis { Type = AxisType.Value, Min = 0, Max = 250 },
        Series = new Series[] { new LineSeries { Data = new List<double>(_values), ShowSymbol = false } }
    };
}
```

### 属性速查

#### WPF 依赖属性

| 属性 | 类型 | 说明 |
| --- | --- | --- |
| `DepOption` | `Option?` | 图表配置（强类型），支持绑定，变更自动刷新 |
| `DepOptionInJs` | `string?` | 图表配置（JSON 字符串），支持绑定 |
| `NotMerge` | `bool` | 是否完全替换配置，默认 `false`（合并） |
| `LazyUpdate` | `bool` | 是否延迟到下一帧渲染，默认 `false` |
| `Loading` | `bool` | 显示/隐藏加载动画，默认 `false` |
| `IsDark` | `bool` | 是否使用深色主题，默认 `false` |
| `ContainerHtml` | `string?` | 自定义容器 HTML，替代默认模板 |
| `ContainerElementId` | `string?` | 自定义容器中图表 div 的 ID，默认 `"root"` |

#### WinForm 属性

| 属性 | 类型 | 说明 |
| --- | --- | --- |
| `ChartOption` | `Option?` | 图表配置（强类型） |
| `ChartOptionInJs` | `string?` | 图表配置（JSON 字符串） |
| `NotMerge` | `bool` | 是否完全替换配置，默认 `false`（合并） |
| `LazyUpdate` | `bool` | 是否延迟到下一帧渲染，默认 `false` |
| `Loading` | `bool` | 显示/隐藏加载动画，默认 `false` |
| `IsDark` | `bool` | 是否使用深色主题，默认 `false` |
| `ContainerHtml` | `string?` | 自定义容器 HTML，替代默认模板 |
| `ContainerElementId` | `string?` | 自定义容器中图表 div 的 ID，默认 `"root"` |

### EChartsReady 事件与 EChart 实例

控件初始化完成后触发 `EChartsReady` 事件，此时可通过 `chart.EChart` 访问底层实例进行更细粒度的操作：

```csharp
chart.EChartsReady += (_, _) =>
{
    // SetOption: 设置图表配置
    chart.EChart.SetOption(option, notMerge: false, lazyUpdate: false);

    // Resize: 手动触发尺寸重算
    chart.EChart.Resize();

    // ShowLoading / HideLoading: 加载动画
    chart.EChart.ShowLoading();
    chart.EChart.HideLoading();
};
```

## 截图
![screenshot](/.github/screenshot-wpf.png)

## 贡献
对本项目有任何疑问，欢迎[提交Issue](https://github.com/AZhrZho/ECharts.Net/issues/new)，或直接发起Pull Request
