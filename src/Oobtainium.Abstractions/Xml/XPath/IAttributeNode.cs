namespace OoBDev.Oobtainium.Xml.XPath;

public interface IAttributeNode : INode
{
    new IAttributeNode? Next { get; }
    new IAttributeNode? Previous { get; }
}
