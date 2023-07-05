using System.Linq.Expressions;
using System.Reflection;

namespace ECharts.Net;

public abstract class JsFuncBase : JsDelegate
{
    protected static string GetRawJs(Expression expression)
    {
        var hostObjectName = expression.Type.GenericTypeArguments[0].Name;
        var rootExp = (UnaryExpression)(expression as LambdaExpression)!.Body;
        var callExp = (MethodCallExpression)rootExp.Operand;
        var methodExp = (ConstantExpression)callExp.Object!;
        var methodInfo = (MethodInfo)methodExp.Value!;
        var methodName = methodInfo.Name;
        var paramterCount = rootExp.Type.GenericTypeArguments.Length - 1;
        var functionName = $"{IWebViewProxy.BridgedObjectHost}.{hostObjectName}.{methodName}";

        var paras = Enumerable.Range(0, paramterCount).Select(x => $"p{x}");
        var paramList = string.Join(',', paras);
        var rawScript = $$"""function({{paramList}}){return {{functionName}}({{paramList}})}""";

        return rawScript;
    }
}

public class JsFunc<TResult> : JsFuncBase
{ 
    public static implicit operator JsFunc<TResult>(string rawFunctionScript)
    {
        return new JsFunc<TResult> { RawJsFunctionString = rawFunctionScript };
    }

    public static implicit operator JsFunc<TResult>(JsRawCall rawFuncCall)
    {
        return new JsFunc<TResult> { RawJsFunctionString = rawFuncCall.RawJsFunctionString };
    }
}

public class JsFunc<T1, TResult> : JsFuncBase
{
    public static implicit operator JsFunc<T1, TResult>(string rawFunctionScript)
    {
        return new JsFunc<T1, TResult> { RawJsFunctionString = rawFunctionScript };
    }

    public static implicit operator JsFunc<T1, TResult>(JsRawCall rawFuncCall)
    {
        return new JsFunc<T1, TResult> { RawJsFunctionString = rawFuncCall.RawJsFunctionString };
    }
}

public class JsFunc<T1, T2, TResult> : JsFuncBase
{
    public static implicit operator JsFunc<T1, T2, TResult>(string rawFunctionScript)
    {
        return new JsFunc<T1, T2, TResult> { RawJsFunctionString = rawFunctionScript };
    }

    public static implicit operator JsFunc<T1, T2, TResult>(JsRawCall rawFuncCall)
    {
        return new JsFunc<T1, T2, TResult> { RawJsFunctionString = rawFuncCall.RawJsFunctionString };
    }
}

public class JsFunc<T1, T2, T3, TResult> : JsFuncBase
{
    public static implicit operator JsFunc<T1, T2, T3, TResult>(string rawFunctionScript)
    {
        return new JsFunc<T1, T2, T3, TResult> { RawJsFunctionString = rawFunctionScript };
    }

    public static implicit operator JsFunc<T1, T2, T3, TResult>(JsRawCall rawFuncCall)
    {
        return new JsFunc<T1, T2, T3, TResult> { RawJsFunctionString = rawFuncCall.RawJsFunctionString };
    }
}

public class JsFunc<T1, T2, T3, T4, TResult> : JsFuncBase
{
    public static implicit operator JsFunc<T1, T2, T3, T4, TResult>(string rawFunctionScript)
    {
        return new JsFunc<T1, T2, T3, T4, TResult> { RawJsFunctionString = rawFunctionScript };
    }

    public static implicit operator JsFunc<T1, T2, T3, T4, TResult>(JsRawCall rawFuncCall)
    {
        return new JsFunc<T1, T2, T3, T4, TResult> { RawJsFunctionString = rawFuncCall.RawJsFunctionString };
    }
}

public class RegisterdJsFunc<THostObject, TResult> : JsFunc<TResult>
{
    public RegisterdJsFunc(Expression<Func<THostObject, Func<TResult>>> methodSelector)
    {
        RawJsFunctionString = GetRawJs(methodSelector);
    }
}

public class RegisterdJsFunc<THostObject, T1, TResult> : JsFunc<T1, TResult>
{
    public RegisterdJsFunc(Expression<Func<THostObject, Func<T1, TResult>>> methodSelector)
    {
        RawJsFunctionString = GetRawJs(methodSelector);
    }
}

public class RegisterdJsFunc<THostObject, T1, T2, TResult> : JsFunc<T1, T2, TResult>
{
    public RegisterdJsFunc(Expression<Func<THostObject, Func<T1, T2, TResult>>> methodSelector)
    {
        RawJsFunctionString = GetRawJs(methodSelector);
    }
}

public class RegisterdJsFunc<THostObject, T1, T2, T3, TResult> : JsFunc<T1, T2, T3, TResult>
{
    public RegisterdJsFunc(Expression<Func<THostObject, Func<T1, T2, T3, TResult>>> methodSelector)
    {
        RawJsFunctionString = GetRawJs(methodSelector);
    }
}

public class RegisterdJsFunc<THostObject, T1, T2, T3, T4, TResult> : JsFunc<T1, T2, T3, T4, TResult>
{
    public RegisterdJsFunc(Expression<Func<THostObject, Func<T1, T2, T3, T4, TResult>>> methodSelector)
    {
        RawJsFunctionString = GetRawJs(methodSelector);
    }
}