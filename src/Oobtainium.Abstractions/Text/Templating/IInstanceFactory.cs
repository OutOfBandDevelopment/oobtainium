using System.Threading.Tasks;

namespace OoBDev.Oobtainium.Text.Templating;

public interface IInstanceFactory
{
    Task<IPathResolver> GetPathResolver(object source);
    Task<IFormatter> GetFormatter(object source);
    Task<ITemplateTransform> GetTemplateTransform(string mediaType);
}
