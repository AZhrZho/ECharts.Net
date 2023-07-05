using System.Linq.Expressions;
using System.Reflection;

namespace ECharts.Net;

public class BridgedFunction
{
    public string RawJsFunctionString { get; private set; } = string.Empty;

    private BridgedFunction(string rawJsFunctionString)
    {
        RawJsFunctionString = rawJsFunctionString;
    }

    private BridgedFunction() { }

    public static BridgedFunction RawCall(string functionName, int paramCount = 0)
    {
        var paras = Enumerable.Range(0, paramCount).Select(x => $"p{x}");
        var paramList = string.Join(',', paras);
        var rawScript = $$"""function({{paramList}}){return {{functionName}}({{paramList}})}""";

        return new BridgedFunction(rawScript);
    }

    public static BridgedFunction NativeAction<THostObject>(Expression<Func<THostObject, Action>> methodSelector)
    {
        return NativeAction(methodSelector as Expression);
    }

    public static BridgedFunction NativeAction<THostObject, T1>(Expression<Func<THostObject, Action<T1>>> methodSelector)
    {
        return NativeAction(methodSelector as Expression);
    }

    public static BridgedFunction NativeAction<THostObject, T1, T2>(Expression<Func<THostObject, Action<T1, T2>>> methodSelector)
    {
        return NativeAction(methodSelector as Expression);
    }

    public static BridgedFunction NativeAction<THostObject, T1, T2, T3>(Expression<Func<THostObject, Action<T1, T2, T3>>> methodSelector)
    {
        return NativeAction(methodSelector as Expression);
    }

    public static BridgedFunction NativeFunc<THostObject, TReturnType>(Expression<Func<THostObject, Func<TReturnType>>> methodSelector)
    {
        return NativeFunction(methodSelector);
    }

    public static BridgedFunction NativeFunc<THostObject, T1, TReturnType>(Expression<Func<THostObject, Func<T1, TReturnType>>> methodSelector)
    {
        return NativeFunction(methodSelector);
    }

    public static BridgedFunction NativeFunc<THostObject, T1, T2, TReturnType>(Expression<Func<THostObject, Func<T1, T2, TReturnType>>> methodSelector)
    {
        return NativeFunction(methodSelector);
    }

    public static BridgedFunction NativeFunc<THostObject, T1, T2, T3, TReturnType>(Expression<Func<THostObject, Func<T1, T2, T3, TReturnType>>> methodSelector)
    {
        return NativeFunction(methodSelector);
    }

    private static BridgedFunction NativeAction(Expression expression)
    {
        var hostObjectName = expression.Type.GenericTypeArguments[0].Name;
        var rootExp = (UnaryExpression)(expression as LambdaExpression)!.Body;
        var callExp = (MethodCallExpression)rootExp.Operand;
        var methodExp = (ConstantExpression)callExp.Object!;
        var methodInfo = (MethodInfo)methodExp.Value!;
        var methodName = methodInfo.Name;
        var paramterCount = rootExp.Type.GenericTypeArguments.Length;
        var functionName = $"{IWebViewProxy.BridgedObjectHost}.{hostObjectName}.{methodName}";
        return RawCall(functionName, paramterCount);
    }

    private static BridgedFunction NativeFunction(Expression expression)
    {
        var hostObjectName = expression.Type.GenericTypeArguments[0].Name;
        var rootExp = (UnaryExpression)(expression as LambdaExpression)!.Body;
        var callExp = (MethodCallExpression)rootExp.Operand;
        var methodExp = (ConstantExpression)callExp.Object!;
        var methodInfo = (MethodInfo)methodExp.Value!;
        var methodName = methodInfo.Name;
        var paramterCount = rootExp.Type.GenericTypeArguments.Length - 1;
        var functionName = $"{IWebViewProxy.BridgedObjectHost}.{hostObjectName}.{methodName}";
        return RawCall(functionName, paramterCount);
    }
}
