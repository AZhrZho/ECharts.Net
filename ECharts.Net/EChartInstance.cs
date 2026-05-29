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
    private string _optionStr; 

    public void SetOption(Option option) 
    {
        _optionStr = JsonSerializer.Serialize(option, SerializerOptions);
        SetOption(_optionStr);
    }

    public void SetOption(dynamic option)
    {
        _optionStr = JsonSerializer.Serialize(option, SerializerOptions);
        SetOption(_optionStr);
    }

    public void SetOption(string optionInJson) 
    {
        _optionStr = $"{instanceName}.setOption({optionInJson})";
        webView.InvokeScriptAsync(_optionStr);
    }

    public void SetTheme(bool isDark)
    {
        string strIsDark = isDark.ToString().ToLower();
        webView.InvokeScriptAsync($"{instanceName}.dispose()");
        webView.InvokeScriptAsync($"{instanceName}=echarts.init(document.getElementById('{Config.EChartsContainerId}'),{strIsDark} ? 'dark' : 'light')");
        webView.InvokeScriptAsync(_optionStr);
    }

    public void Resize()
    {
        webView.InvokeScriptAsync($"{instanceName}.resize()");
    }

    public void RegisterScriptObject<T>()
    {
        var typeName = typeof(T).Name;
        var instance = Activator.CreateInstance<T>();
        webView.AddBridgeObject(typeName, instance!);
    }

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
