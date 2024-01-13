using System;

namespace OoBDev.Oobtainium.ExpressionCalculator.Expressions;

public static class OperatorExtensions
{
    public static string AsString(this UnaryOperators @operator) =>
        @operator switch
        {
            UnaryOperators.Negate => "-",
            UnaryOperators.Factorial => "!",

            _ => throw new NotSupportedException($"Operator {@operator} not supported")
        };

    public static bool IsRight(this UnaryOperators @operator) =>
        @operator switch
        {
            UnaryOperators.Negate => false,
            UnaryOperators.Factorial => true,

            _ => throw new NotSupportedException($"Operator {@operator} not supported")
        };

    public static UnaryOperators AsUnaryOperator(this string input) =>
        input switch
        {
            "-" => UnaryOperators.Negate,
            "!" => UnaryOperators.Factorial,

            _ => UnaryOperators.Unknown
        };

    public static string AsString(this BinaryOperators @operator) =>
        @operator switch
        {
            BinaryOperators.Power => "^",
            
            BinaryOperators.Multiply => "*",
            BinaryOperators.Divide => "/",
            BinaryOperators.Modulo =>"%",
            
            BinaryOperators.Add => "+",
            BinaryOperators.Subtract => "-",

            _ => $"?{@operator}?"
        };

    public static BinaryOperators AsBinaryOperators(this string input) =>
        input switch
        {
            "^" => BinaryOperators.Power,

            "*" => BinaryOperators.Multiply,
            "/" => BinaryOperators.Divide,
            "%" => BinaryOperators.Modulo,

            "+" => BinaryOperators.Add,
            "-" => BinaryOperators.Subtract,

            _ => BinaryOperators.Unknown
        };

    public static int GetPriority(this BinaryOperators @operator) =>
        @operator switch
        {
            BinaryOperators.Power => 3,

            BinaryOperators.Multiply => 2,
            BinaryOperators.Divide => 2,
            BinaryOperators.Modulo => 2,

            BinaryOperators.Add => 1,
            BinaryOperators.Subtract => 1,

            _ => int.MaxValue,
        };
}
