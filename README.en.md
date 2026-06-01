# ECharts.Net - Bring ECharts into .NET applications

[![NuGet Badge](https://buildstats.info/nuget/ECharts.Net.Core?includePreReleases=true)](https://www.nuget.org/packages/ECharts.Net.Core/0.0.4)

<div align=center><img height='100' src=".github/icon.png"></div>

<br/>

<div align=center>
  <font size='4'>
    <a href='/README.md'>简体中文</a> | <strong>English</strong>
  </font>
</div>

## Roadmap

This project is currently in the early stages of development. Basic functionality has been implemented, and all official ECharts examples can theoretically be achieved via direct JS calls. Current focus is on encapsulating the `Option` type.

| Item                                   | Status      |
| -------------------------------------- | ----------- |
| Basic WebView2 control encapsulation   | ✅          |
| Core type system design                | ✅          |
| **`Option` type encapsulation**        | In progress |
| WinUI3 support                         | Planned     |
| Serialization and interop optimization | Planned     |
| .NET Framework support                 | ✅          |

---

## Table of Contents

- [Introduction](#introduction)
- [Getting Started](#getting-started)
  - [Quick Start](#quick-start)
  - [Property Reference](#property-reference)
  - [Real-time Data Updates](#real-time-data-updates)
  - [Property Cheat Sheet](#property-cheat-sheet)
  - [EChartsReady Event & EChart Instance](#echartsready-event--echart-instance)
- [Screenshot](#screenshot)
- [Contributing](#contributing)

---

## Introduction

A chart control library for WPF/WinForms, powered by WebView2 with ECharts embedded. Built on modern .NET technologies while maintaining .NET Framework compatibility.

## Features

- Modern: Built on .NET 7 and WebView2
- High Performance: Minimal overhead for ECharts interop
- Type Safe: Strongly-typed encapsulation of ECharts components
- Flexible: Use .NET types or raw JavaScript strings interchangeably

## Getting Started

Install via NuGet package manager:

| Platform | Package                                                                      |
| -------- | ---------------------------------------------------------------------------- |
| WinForms | [`ECharts.Net.Winform`](https://www.nuget.org/packages/ECharts.Net.Winform/) |
| WPF      | [`ECharts.Net.Wpf`](https://www.nuget.org/packages/ECharts.Net.Wpf/)         |
| WinUI3   | Not yet supported                                                            |

Since we are in the early stages of development, there is no complete documentation yet. For detailed usage, please refer to the demo projects in this repository.

### Quick Start

#### WPF

**XAML declaration:**

```xml
xmlns:echarts="clr-namespace:ECharts.Net.Wpf;assembly=ECharts.Net.Wpf"

<echarts:EChartsView x:Name="chart" />
```

**Data binding (recommended):**

```xml
<echarts:EChartsView DepOption="{Binding ChartOption}"
                      Loading="{Binding IsLoading}" />
```

```csharp
// In ViewModel, the chart refreshes automatically on property change (built-in 16ms debounce)
public Option? ChartOption
{
    get => _chartOption;
    set => SetProperty(ref _chartOption, value);
}
```

**Code-behind:**

```csharp
var option = new Option
{
    XAxis = new XAxis { Type = AxisType.Category, Data = new[] { "A", "B", "C" } },
    YAxis = new YAxis { Type = AxisType.Value },
    Series = new Series[] { new LineSeries { Data = new double[] { 10, 20, 30 } } }
};

// WPF: set via dependency property
chart.DepOption = option;

// WinForms: direct assignment
chart.ChartOption = option;
```

### Property Reference

#### DepOption / ChartOption — Chart Configuration (Strongly Typed)

Configure charts using the `Option` object with IntelliSense and compile-time checking.

```csharp
var option = new Option
{
    Title = new Title { Text = "Chart Title" },
    Tooltip = new() { Trigger = TooltipTrigger.Axis },
    Legend = new Legend { Data = new LegendData[] { "Series A", "Series B" } },
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

**WPF binding:** Property name is `DepOption`, supports XAML data binding

```xml
<echarts:EChartsView DepOption="{Binding ChartOption}" />
```

**WinForms:** Property name is `ChartOption`, assign directly

```csharp
chart.ChartOption = option;
```

> In WPF binding mode, property changes automatically refresh the chart with a built-in 16ms debounce.

#### DepOptionInJs / ChartOptionInJs — Chart Configuration (JSON String)

When the strongly-typed API hasn't covered certain ECharts features, you can pass raw ECharts JSON configuration for full feature access.

```csharp
var optionJs = """
    {
        "title": { "text": "JS Config" },
        "xAxis": { "type": "category", "data": ["A", "B", "C"] },
        "yAxis": { "type": "value" },
        "series": [{ "type": "line", "data": [10, 20, 30] }]
    }
    """;

// WPF
chart.DepOptionInJs = optionJs;

// WinForms
chart.ChartOptionInJs = optionJs;
```

**WPF binding:**

```xml
<echarts:EChartsView DepOptionInJs="{Binding ChartOptionInJs}" />
```

> When both `DepOption` and `DepOptionInJs` are set, `DepOption` takes priority.

#### Loading — Loading Animation

Controls the visibility of the chart loading overlay, useful during data fetching.

```csharp
// Show loading animation
chart.Loading = true;

// Hide after data is loaded
chart.Loading = false;
```

**WPF binding:**

```xml
<echarts:EChartsView Loading="{Binding IsLoading}" />
```

#### NotMerge — Configuration Merge Mode

Controls whether `setOption` merges with the existing configuration. Default is `false` (merge), set to `true` to fully replace.

```csharp
// Default: new config merges with existing
chart.NotMerge = false;

// Fully replace existing config
chart.NotMerge = true;
```

**WPF binding:**

```xml
<echarts:EChartsView DepOption="{Binding ChartOption}" NotMerge="True" />
```

#### LazyUpdate — Deferred Rendering

When set to `true`, `setOption` does not render immediately but batches updates to the next animation frame. Useful for high-frequency data updates.

```csharp
chart.LazyUpdate = true;
```

**WPF binding:**

```xml
<echarts:EChartsView DepOption="{Binding ChartOption}" LazyUpdate="True" />
```

#### ContainerHtml — Custom Container HTML

Replaces the built-in HTML template for customizing the page structure (e.g., adding extra CSS, changing background color). The ECharts engine script is automatically injected after setting.

> **Note:** Must be set before control initialization (before the `EChartsReady` event fires). The HTML must contain a `<div>` element as the chart container.

**WPF (XAML):**

```xml
<echarts:EChartsView ContainerHtml="{Binding MyHtml}"
                      ContainerElementId="chart1" />
```

**WPF (code):**

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

**WinForms:**

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

#### ContainerElementId — Chart Container Element ID

Used together with `ContainerHtml`, specifies the `id` of the chart `<div>` in the custom HTML. Defaults to `"root"` when not set.

### Real-time Data Updates

In WPF binding mode, simply update the ViewModel property and the chart refreshes automatically:

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

    // Update property — chart refreshes automatically
    ChartOption = new Option
    {
        XAxis = new XAxis { Type = AxisType.Category, Data = new List<string>(_times) },
        YAxis = new YAxis { Type = AxisType.Value, Min = 0, Max = 250 },
        Series = new Series[] { new LineSeries { Data = new List<double>(_values), ShowSymbol = false } }
    };
}
```

### Property Cheat Sheet

#### WPF Dependency Properties

| Property             | Type      | Description                                                             |
| -------------------- | --------- | ----------------------------------------------------------------------- |
| `DepOption`          | `Option?` | Chart config (strongly typed), supports binding, auto-refresh on change |
| `DepOptionInJs`      | `string?` | Chart config (JSON string), supports binding                            |
| `NotMerge`           | `bool`    | Fully replace config instead of merging, default `false`                |
| `LazyUpdate`         | `bool`    | Defer rendering to next frame, default `false`                          |
| `Loading`            | `bool`    | Show/hide loading animation, default `false`                            |
| `ContainerHtml`      | `string?` | Custom container HTML, replaces default template                        |
| `ContainerElementId` | `string?` | Chart div ID in custom HTML, default `"root"`                           |

#### WinForms Properties

| Property             | Type      | Description                                              |
| -------------------- | --------- | -------------------------------------------------------- |
| `ChartOption`        | `Option?` | Chart config (strongly typed)                            |
| `ChartOptionInJs`    | `string?` | Chart config (JSON string)                               |
| `NotMerge`           | `bool`    | Fully replace config instead of merging, default `false` |
| `LazyUpdate`         | `bool`    | Defer rendering to next frame, default `false`           |
| `Loading`            | `bool`    | Show/hide loading animation, default `false`             |
| `ContainerHtml`      | `string?` | Custom container HTML, replaces default template         |
| `ContainerElementId` | `string?` | Chart div ID in custom HTML, default `"root"`            |

### EChartsReady Event & EChart Instance

The `EChartsReady` event fires when the control has finished initializing. At this point you can access the underlying `EChart` instance for fine-grained control:

```csharp
chart.EChartsReady += (_, _) =>
{
    // SetOption: set chart configuration
    chart.EChart.SetOption(option, notMerge: false, lazyUpdate: false);

    // Resize: manually trigger resize
    chart.EChart.Resize();

    // ShowLoading / HideLoading: loading animation
    chart.EChart.ShowLoading();
    chart.EChart.HideLoading();
};
```

## Screenshot

![screenshot](/.github/screenshot-wpf.png)

## Contributing

Any [Issues](https://github.com/AZhrZho/ECharts.Net/issues/new) or PRs related to this project are welcome.
