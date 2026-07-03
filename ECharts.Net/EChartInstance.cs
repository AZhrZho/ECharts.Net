using ECharts.Net.JsonConverter;

namespace ECharts.Net;

public class EChartInstance
{
    public EChartInstance(IWebViewProxy webView, string instanceName = "chart")
    {
        this.webView = webView;
        this.instanceName = instanceName;
    }

    private readonly IWebViewProxy webView;
    private readonly string instanceName;
    private int _optionCounter;
    private const int LargeOptionThreshold = 32 * 1024;
    private string? _optionStr;

    public void SetOption(Option option, bool? notMerge = null, bool? lazyUpdate = null, string? replaceMerge = null)
    {
        SetOption(JsonSerializer.Serialize(option, SerializerOptions), notMerge, lazyUpdate, replaceMerge);
    }

    public void SetOption(dynamic option, bool? notMerge = null, bool? lazyUpdate = null, string? replaceMerge = null)
    {
        SetOption(JsonSerializer.Serialize(option, SerializerOptions), notMerge, lazyUpdate, replaceMerge);
    }

    public void SetOption(string optionInJson, bool? notMerge = null, bool? lazyUpdate = null, string? replaceMerge = null)
    {
        _optionStr = optionInJson;
        var setOptionArgs = BuildSetOptionArgs(notMerge, lazyUpdate, replaceMerge);

        if (optionInJson.Length > LargeOptionThreshold)
        {
            var varName = $"__opt{Interlocked.Increment(ref _optionCounter)}";
            webView.InvokeScriptAsync(
                $"window.{varName}={optionInJson};{instanceName}.setOption(window.{varName}{setOptionArgs});delete window.{varName}");
        }
        else
        {
            webView.InvokeScriptAsync($"{instanceName}.setOption({optionInJson}{setOptionArgs})");
        }
    }

    private static string BuildSetOptionArgs(bool? notMerge, bool? lazyUpdate, string? replaceMerge)
    {
        if (notMerge == null && lazyUpdate == null && replaceMerge == null)
            return "";

        var parts = new List<string>();
        if (notMerge.HasValue) parts.Add($"notMerge:{notMerge.Value.ToString().ToLowerInvariant()}");
        if (lazyUpdate.HasValue) parts.Add($"lazyUpdate:{lazyUpdate.Value.ToString().ToLowerInvariant()}");
        if (replaceMerge != null) parts.Add($"replaceMerge:{replaceMerge}");

        return $",{{{string.Join(",", parts)}}}";
    }

    public void SetTheme(bool isDark)
    {
        var themeArg = isDark ? "'dark'" : "null";
        webView.InvokeScriptAsync($"{instanceName}.dispose()");
        webView.InvokeScriptAsync($"{instanceName}=echarts.init(document.getElementById('{Config.EChartsContainerId}'),{themeArg})");
        if (!string.IsNullOrEmpty(_optionStr))
        {
            webView.InvokeScriptAsync($"{instanceName}.setOption({_optionStr})");
        }
    }

    public void Resize()
    {
        webView.InvokeScriptAsync($"{instanceName}.resize()");
    }

    public void ShowLoading()
    {
        webView.InvokeScriptAsync($"{instanceName}.showLoading()");
    }

    public void HideLoading()
    {
        webView.InvokeScriptAsync($"{instanceName}.hideLoading()");
    }

    public void RegisterScriptObject<T>()
    {
        var typeName = typeof(T).Name;
        var instance = Activator.CreateInstance<T>();
        webView.AddBridgeObject(typeName, instance!);
    }

    public async Task RegisterFunctionRawAsync(string rawScript)
    {
        await webView.InvokeScriptAsync(rawScript);
    }

    [Obsolete("Use RegisterFunctionRawAsync instead.")]
    public void RegisterFunctionRaw(string rawScript)
    {
        webView.InvokeScriptAsync(rawScript).GetAwaiter().GetResult();
    }

    private static JsonSerializerOptions SerializerOptions { get; }

    static EChartInstance()
    {
        SerializerOptions = new JsonSerializerOptions();

        SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, false));
        SerializerOptions.Converters.Add(new JsonHexColorConverter());
        SerializerOptions.Converters.Add(new JsonHexSolidColorConverter());
        SerializerOptions.Converters.Add(new JsonIntersectedConverter());
        SerializerOptions.Converters.Add(new JsonThicknessConverter());
        SerializerOptions.Converters.Add(new JsonSeriesListConverter());

        SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    }
}