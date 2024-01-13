using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OoBDev.Oobtainium.ComponentModel;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    /*
    * WeakEventManager
	        * http://www.codeproject.com/Articles/786606/WeakEventManager-for-WinRT
	        * http://reedcopsey.com/2009/08/06/preventing-event-based-memory-leaks-weakeventmanager/
	        * https://msdn.microsoft.com/en-us/library/system.windows.weakeventmanager.aspx
	        * http://www.jonathanantoine.com/2011/09/19/wpf-4-5-part-2-improved-weakeventmanager/
	    */
    protected ViewModelBase(Action<Action> dispatched)
    {
        Dispatched = dispatched;
    }
    public Action<Action> Dispatched { get; }
    public void DispatchWork(Action work)
    {
        if (Dispatched == null)
            work();
        else
            Dispatched(work);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        DispatchWork(() =>
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        });
    }
}
