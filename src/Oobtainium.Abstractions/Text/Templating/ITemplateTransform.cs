using System.Threading.Tasks;

namespace OoBDev.Oobtainium.Text.Templating;

public interface ITemplateTransform
{
    Task<string> Transform(object source, string template);
}
