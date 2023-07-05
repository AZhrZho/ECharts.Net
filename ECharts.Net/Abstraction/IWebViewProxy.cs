namespace ECharts.Net;

public interface IWebViewProxy
{
    Task<string> InvokeScriptAsync(string script);
    Task InitializeEchartsEngineAsync();
    Task AddBridgeObject(string key, object bridgeObject);

    public static string BridgedObjectHost { get; set; } = string.Empty;
}
