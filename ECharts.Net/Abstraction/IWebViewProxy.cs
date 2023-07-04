namespace ECharts.Net;

public interface IWebViewProxy
{
    Task<string> InvokeScriptAsync(string script);
    Task InitializeEchartsEngineAsync();
}
