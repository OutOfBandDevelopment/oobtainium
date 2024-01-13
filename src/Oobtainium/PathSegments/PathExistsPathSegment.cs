namespace OoBDev.Oobtainium.PathSegments;

public class PathExistsPathSegment(BinaryPathSegment path) : BaseValuePathSegment<BinaryPathSegment>(path)
{
    public override string ToString() => $"[{Value}]";
}