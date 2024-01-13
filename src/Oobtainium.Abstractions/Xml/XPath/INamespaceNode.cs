namespace OoBDev.Oobtainium.Xml.XPath;

public interface INamespaceNode : INode
{
    new INamespaceNode? Next { get; }
    new INamespaceNode? Previous { get; }
}
