using System.Xml.Linq;
using System.Xml.XPath;

namespace OoBDev.Oobtainium.Xml.XPath;

public interface INode
{
    XName Name { get; }

    INode? Parent { get; }
    INode? Next { get; }
    INode? Previous { get; }

    string? Value { get; }
    XPathNodeType NodeType { get; }
}
