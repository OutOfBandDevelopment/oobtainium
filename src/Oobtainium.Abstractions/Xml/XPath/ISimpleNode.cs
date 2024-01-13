namespace OoBDev.Oobtainium.Xml.XPath;

public interface ISimpleNode : IElementNode
{
    new INode? Next { set; }
    new INode? Previous { set; }
}
