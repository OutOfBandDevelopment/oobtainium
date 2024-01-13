using OoBDev.Oobtainium.Xml.Linq;
using System.Data.SqlTypes;

namespace OoBDev.Oobtainium.Data.SqlTypes;

public static class SqlXmlEx
{
    public static XFragment ToXFragment(this SqlXml sqlxml)
    {
        using var xmlReader = sqlxml.CreateReader();
        return XFragment.Parse(xmlReader);
    }

    public static SqlXml ToSqlXml(this XFragment xFragment) => new(xFragment.CreateReader());
}
