using System.Diagnostics;
using System.Threading.Tasks;

namespace OoBDev.Oobtainium.Tests.TestTargets;

public class ClassWithInterface : IAnotherInterface
{
    public int DoWork(string abc)
    {
        Debug.WriteLine($"{this}::{nameof(DoWork)} {abc}");
        return abc?.Length ?? -1;
    }

    public Task<int> DoWork2(string abc)
    {
        Debug.WriteLine($"{this}::{nameof(DoWork)} {abc}");
        return Task.FromResult(abc?.Length ?? -1);
    }
}
