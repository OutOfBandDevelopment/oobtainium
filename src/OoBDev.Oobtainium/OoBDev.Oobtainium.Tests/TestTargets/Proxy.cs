using OoBDev.Oobtainium.Reflection;
using System.Diagnostics;
using System.Reflection;

namespace OoBDev.Oobtainium.Tests.TestTargets
{
    public class Proxy<T> : WrappedDispatchProxy<T>
    {
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            Debug.WriteLine($"\t:> {typeof(T)}::{targetMethod}");
            if (targetMethod.DeclaringType.IsInstanceOfType(this.Instance))
            {
                return targetMethod.Invoke(this.Instance, args);
            }
            else
            {
                return targetMethod.ReturnType.GetDefaultValue();
            }
        }
    }
}
