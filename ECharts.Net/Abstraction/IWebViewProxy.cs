namespace ECharts.Net;

public interface IWebViewProxy
{
    Task<string> InvokeScriptAsync(string script);
    Task InitializeEchartsEngineAsync(bool isDarkTheme = false);
    Task AddBridgeObject(string key, object bridgeObject);
}

public static class WebViewProxy
{
    public static string BridgedObjectHost { get; set; } = string.Empty;
}
