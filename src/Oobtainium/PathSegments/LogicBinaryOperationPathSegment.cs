namespace OoBDev.Oobtainium.PathSegments;

public class LogicBinaryOperationPathSegment(
    IPathSegment left,
    IPathSegment<LogicOperationTypes> @operator,
    IPathSegment right
        ) : BinaryOperationPathSegment<LogicOperationTypes>(left, @operator, right)
{
}