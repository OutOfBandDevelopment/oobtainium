using OoBDev.Oobtainium.ExpressionCalculator.Expressions;
using System;

namespace OoBDev.Oobtainium.ExpressionCalculator.Optimizers;

public sealed class IdentityExpressionOptimizer<T> : IExpressionOptimizer<T> where T : struct, IComparable<T>, IEquatable<T>
{
    public ExpressionBase<T> Optimize(ExpressionBase<T> expression) =>
        expression switch
        {
            InnerExpression<T> inner => new InnerExpression<T>(Optimize(inner.Expression)),
            BinaryOperatorExpression<T> binaryOperator => Optimize(binaryOperator),
            _ => expression
        };

    // simplify identity
    // B^1 => B
    // 1*B | B*1 => B
    // B*-1=>-B
    // -1*B=>-B
    // B/1 => B
    // B/-1=>-B
    // 0+B | B+0 => B
    // B-0 => B
    // 0-B=>-B
    // -(1) => -1
    private ExpressionBase<T> Optimize(BinaryOperatorExpression<T> expression)
    {
        var left = Optimize(expression.Left);
        var right = Optimize(expression.Right);

        ExpressionBase<T> result = (expression.Operator, GetValue(left), GetValue(right)) switch
        {
            (BinaryOperators.Power, _, 1) => left,
             
            (BinaryOperators.Multiply, 1, _) => right,
            (BinaryOperators.Multiply, _, 1) => left,
            (BinaryOperators.Multiply, -1, _) => new UnaryOperatorExpression<T>(UnaryOperators.Negate, right),
            (BinaryOperators.Multiply, _, -1) => new UnaryOperatorExpression<T>(UnaryOperators.Negate, left),
             
            (BinaryOperators.Divide, _, 1) => left,
            (BinaryOperators.Divide, _, -1) => new UnaryOperatorExpression<T>(UnaryOperators.Negate, left),
             
            (BinaryOperators.Add, _, 0) => left,
            (BinaryOperators.Add, 0, _) => right,
             
            (BinaryOperators.Subtract, _, 0) => left,
            (BinaryOperators.Subtract, 0, _) => new UnaryOperatorExpression<T>(UnaryOperators.Negate, right),

            _ => new BinaryOperatorExpression<T>(left, expression.Operator, right)
        };

        return result;
    }

    private int? GetValue(ExpressionBase<T> expression) =>
        expression switch
        {
            NumberExpression<T> num => Convert.ToInt32(num.Value),
            UnaryOperatorExpression<T> unaryOp => 0 - GetValue(unaryOp.Operand),
            _ => null
        };
}
