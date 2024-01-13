using OoBDev.Oobtainium.ExpressionCalculator.Expressions;
using System;

namespace OoBDev.Oobtainium.ExpressionCalculator.Optimizers;

public sealed class DeterminedExpressionReducer<T> : IExpressionOptimizer<T> where T : struct, IComparable<T>, IEquatable<T>
{
    public ExpressionBase<T> Optimize(ExpressionBase<T> expression) =>
        expression switch
        {
            InnerExpression<T> inner => new InnerExpression<T>(Optimize(inner.Expression)),
            BinaryOperatorExpression<T> binaryOperator => Optimize(binaryOperator),
            _ => expression
        };


    /// simplify determined
    // #`?#`` => #```
    // B/B => 1
    // B%B => 0
    // B^0 => 1
    // 0^B => 0
    // B*0 | 0*B => 0
    // B/0 => exception!
    // 0/B => 0
    // B%0 => exception!
    // 0%B => 0
    // B%1 => 0
    // B%-1 => 0	
    private ExpressionBase<T> Optimize(BinaryOperatorExpression<T> expression)
    {
        var left = Optimize(expression.Left);
        var right = Optimize(expression.Right);

        if (left is NumberExpression<T> && right is NumberExpression<T>)
        {
            return new NumberExpression<T>(
                new BinaryOperatorExpression<T>(left, expression.Operator, right).Evaluate(
                    ExpressionBaseExtensions.EmptySet<T>()
                    )
                );
        }

        ExpressionBase<T> result = (expression.Operator, GetValue(left), GetValue(right)) switch
        {
            (BinaryOperators.Power, _, 0) => NumberExpression<T>.One,
            (BinaryOperators.Power, 0, _) => NumberExpression<T>.Zero,
             
            (BinaryOperators.Multiply, 0, _) => NumberExpression<T>.Zero,
            (BinaryOperators.Multiply, _, 0) => NumberExpression<T>.Zero,
             
            (BinaryOperators.Divide, _, 0) => throw new DivideByZeroException(),
            (BinaryOperators.Divide, 0, _) => NumberExpression<T>.Zero,
            (BinaryOperators.Divide, _, _) when left.Equals(right) => NumberExpression<T>.One,
             
            (BinaryOperators.Modulo, _, 0) => throw new DivideByZeroException(),
            (BinaryOperators.Modulo, 0, _) => NumberExpression<T>.Zero,
            (BinaryOperators.Modulo, _, 1) => NumberExpression<T>.Zero,
            (BinaryOperators.Modulo, _, -1) => NumberExpression<T>.Zero,
            (BinaryOperators.Modulo, _, _) when left.Equals(right) => NumberExpression<T>.Zero,

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
