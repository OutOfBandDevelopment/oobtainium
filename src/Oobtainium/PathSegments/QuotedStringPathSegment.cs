namespace OoBDev.Oobtainium.PathSegments;

public sealed class QuotedStringPathSegment(string value) : BaseValuePathSegment<string>(value)
{
    public override string ToString() => $@"""{Value}""";
}