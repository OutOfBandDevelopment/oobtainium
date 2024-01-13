using System.Linq.Expressions;
using System.Reflection;

namespace OoBDev.Oobtainium;

public static class ExpressionExtensions
{
    public static MethodInfo? AsMethodInfo(this Expression? expression) => ((expression as LambdaExpression)?.Body as MethodCallExpression)?.Method;
}
