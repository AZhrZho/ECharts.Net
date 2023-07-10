using System.Linq.Expressions;
using System.Reflection;

namespace ECharts.Net;

public abstract class JsActionBase : JsDelegate
{
    // TODO refactor JsActions
    protected static string GetRawJs(Expression expression)
    {
        var hostObjectName = expression.Type.GenericTypeArguments[0].Name;
        var rootExp = (UnaryExpression)(expression as LambdaExpression)!.Body;
        var callExp = (MethodCallExpression)rootExp.Operand;
        var methodExp = (ConstantExpression)callExp.Object!;
        var methodInfo = (MethodInfo)methodExp.Value!;
        var methodName = methodInfo.Name;
        var paramterCount = rootExp.Type.GenericTypeArguments.Length;
        var ActiontionName = $"{IWebViewProxy.BridgedObjectHost}.{hostObjectName}.{methodName}";

        var paras = Enumerable.Range(0, paramterCount).Select(x => $"p{x}");
        var paramList = string.Join(',', paras);
        var rawScript = $$"""function({{paramList}}){{{ActiontionName}}({{paramList}})}""";

        return rawScript;
    }
}

public class JsAction : JsActionBase
{
    public static implicit operator JsAction(string rawActiontionScript)
    {
        return new JsAction { RawJsFunctionString = rawActiontionScript };
    }

    public static implicit operator JsAction(JsRawCall rawFuncCall)
    {
        return new JsAction { RawJsFunctionString = rawFuncCall.RawJsFunctionString };
    }
}

public class JsAction<T1> : JsActionBase
{
    public static implicit operator JsAction<T1>(string rawActiontionScript)
    {
        return new JsAction<T1> { RawJsFunctionString = rawActiontionScript };
    }

    public static implicit operator JsAction<T1>(JsRawCall rawFuncCall)
    {
        return new JsAction<T1> { RawJsFunctionString = rawFuncCall.RawJsFunctionString };
    }
}

public class JsAction<T1, T2> : JsActionBase
{
    public static implicit operator JsAction<T1, T2>(string rawActiontionScript)
    {
        return new JsAction<T1, T2> { RawJsFunctionString = rawActiontionScript };
    }

    public static implicit operator JsAction<T1, T2>(JsRawCall rawFuncCall)
    {
        return new JsAction<T1, T2> { RawJsFunctionString = rawFuncCall.RawJsFunctionString };
    }
}

public class JsAction<T1, T2, T3> : JsActionBase
{
    public static implicit operator JsAction<T1, T2, T3>(string rawActiontionScript)
    {
        return new JsAction<T1, T2, T3> { RawJsFunctionString = rawActiontionScript };
    }

    public static implicit operator JsAction<T1, T2, T3>(JsRawCall rawFuncCall)
    {
        return new JsAction<T1, T2, T3> { RawJsFunctionString = rawFuncCall.RawJsFunctionString };
    }
}

public class JsAction<T1, T2, T3, T4> : JsActionBase
{
    public static implicit operator JsAction<T1, T2, T3, T4>(string rawActiontionScript)
    {
        return new JsAction<T1, T2, T3, T4> { RawJsFunctionString = rawActiontionScript };
    }

    public static implicit operator JsAction<T1, T2, T3, T4>(JsRawCall rawFuncCall)
    {
        return new JsAction<T1, T2, T3, T4> { RawJsFunctionString = rawFuncCall.RawJsFunctionString };
    }
}

public class RegisterdJsAction : JsAction
{
    public RegisterdJsAction(Expression<Func<Action>> methodSelector)
    {
        RawJsFunctionString = GetRawJs(methodSelector);
    }
}

public class RegisterdJsAction<T1> : JsAction<T1>
{
    public RegisterdJsAction(Expression<Func<Action<T1>>> methodSelector)
    {
        RawJsFunctionString = GetRawJs(methodSelector);
    }
}

public class RegisterdJsAction<T1, T2> : JsAction<T1, T2>
{
    public RegisterdJsAction(Expression<Func<Action<T1, T2>>> methodSelector)
    {
        RawJsFunctionString = GetRawJs(methodSelector);
    }
}

public class RegisterdJsAction<T1, T2, T3> : JsAction<T1, T2, T3>
{
    public RegisterdJsAction(Expression<Func<Action<T1, T2, T3>>> methodSelector)
    {
        RawJsFunctionString = GetRawJs(methodSelector);
    }
}

public class RegisterdJsAction<T1, T2, T3, T4> : JsAction<T1, T2, T3, T4>
{
    public RegisterdJsAction(Expression<Func<Action<T1, T2, T3, T4>>> methodSelector)
    {
        RawJsFunctionString = GetRawJs(methodSelector);
    }
}
