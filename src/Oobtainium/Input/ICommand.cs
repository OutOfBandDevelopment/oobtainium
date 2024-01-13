namespace OoBDev.Oobtainium.Input;

public interface ICommand : System.Windows.Input.ICommand
{
    void RaiseCanExecuteChanged();
}
