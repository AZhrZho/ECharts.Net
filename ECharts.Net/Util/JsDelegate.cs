namespace ECharts.Net;

public abstract class JsDelegate
{
    public string RawJsFunctionString { get; protected set; } = null!;
}

public class JsRawCall : JsDelegate
{
    public JsRawCall(string funcName, int paramsCount)
    {
        FuncName = funcName;
        var paras = Enumerable.Range(0, paramsCount).Select(x => $"p{x}");
        var paramList = string.Join(',', paras);
        RawJsFunctionString = $$"""function({{paramList}}){return {{funcName}}({{paramList}})}""";
    }

    public JsRawCall(string rawFunctionScript) 
    {
        FuncName = string.Empty;
        RawJsFunctionString = rawFunctionScript;
    }

    public string FuncName { get; init; }
}