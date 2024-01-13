using System.Threading.Tasks;

namespace OoBDev.Oobtainium.Text.Templating;

public interface IPathResolver
{
    Task<object> ItemSelector(string path);
}
