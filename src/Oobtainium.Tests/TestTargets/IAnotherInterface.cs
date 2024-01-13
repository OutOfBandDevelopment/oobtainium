using System.Threading.Tasks;

namespace OoBDev.Oobtainium.Tests.TestTargets;

public interface IAnotherInterface
{
    int DoWork(string abc);

    Task<int> DoWork2(string abc);
}
