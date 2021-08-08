using System.Threading.Tasks;

namespace OoBDev.Oobtainium.Tests.TestTargets
{
    public interface ITargetInterface
    {
        string this[int index] { get; set; }
        int Test { get; set; }

        string ReturnValue();
        void VoidReturn();
        void VoidReturnWithInput(object input);
        void VoidReturnWithGenericInput<T>(T input);
        T ReturnWithGenericInput<T>(T input);
        Task VoidReturnAsync();
        Task VoidReturnWithInputAsync(string input);
        Task VoidReturnWithGenericInputAsync<T>(T input);
        Task<object> InvokeAsync();
        Task<T> InvokeAsync<T>();
        Task<T> InvokeAsync<T>(T input);
        Task<T> InvokeAsync<T>(string input);
    }
}
