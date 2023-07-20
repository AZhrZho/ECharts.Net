using System;
using System.Threading.Tasks;

namespace ECharts.Net;

public class CefProxy : IWebViewProxy
{
    public Task AddBridgeObject(string key, object bridgeObject)
    {
        throw new NotImplementedException();
    }

    public Task InitializeEchartsEngineAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> InvokeScriptAsync(string script)
    {
        throw new NotImplementedException();
    }
}
