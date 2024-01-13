using OoBDev.Oobtainium.ExpressionCalculator.Evaluators;
using System;
using System.Collections.Generic;

namespace OoBDev.Oobtainium.ExpressionCalculator.Expressions;

public sealed class BinaryOperatorExpression<T>(
    ExpressionBase<T> left,
    BinaryOperators @operator,
    ExpressionBase<T> right
        ) : ExpressionBase<T>
    where T : struct, IComparable<T>, IEquatable<T>
{
    private static readonly IExpressionEvaluator<T> _evaluator = ExpressionEvaluatorFactory.Create<T>();

    public ExpressionBase<T> Left { get; } = left;
    public BinaryOperators Operator { get; } = @operator;
    public ExpressionBase<T> Right { get; } = right;

    public override ExpressionBase<T> Clone() => new BinaryOperatorExpression<T>(Left.Clone(), Operator, Right.Clone());

    public override T Evaluate(IDictionary<string, T> variables) =>
        Operator switch
        {
            BinaryOperators.Power => _evaluator.Power(Left.Evaluate(variables), Right.Evaluate(variables)),

            BinaryOperators.Multiply => _evaluator.Multiply(Left.Evaluate(variables), Right.Evaluate(variables)),
            BinaryOperators.Divide => _evaluator.Divide(Left.Evaluate(variables), Right.Evaluate(variables)),
            BinaryOperators.Modulo => _evaluator.Modulo(Left.Evaluate(variables), Right.Evaluate(variables)),

            BinaryOperators.Add => _evaluator.Add(Left.Evaluate(variables), Right.Evaluate(variables)),
            BinaryOperators.Subtract => _evaluator.Subtract(Left.Evaluate(variables), Right.Evaluate(variables)),

            _ => throw new NotSupportedException($"Operator {Operator} not supported")
        };

    public override string ToString() => $"{Left} {Operator.AsString()} {Right}";
}
