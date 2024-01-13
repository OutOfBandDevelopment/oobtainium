using System.Threading.Tasks;

namespace OoBDev.Oobtainium.Text.Templating;

public interface IFormatter
{
    bool CanFormat(object source);
    Task<string?> Format(object source, string format);
}
