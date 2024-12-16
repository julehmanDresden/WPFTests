using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfTest.Commands;

public class DelegateCommand : ICommand
{
    private readonly Action<object> _execute;
    private readonly Predicate<object> _canExecute;
    
    /// <summary>
    /// Delegate Command for e.g. Button
    /// </summary>
    /// <param name="canExecute"></param>
    /// <param name="execute"></param>
    public DelegateCommand(Predicate<object> canExecute, Action<object> execute) =>
    (this._canExecute, this._execute) = (canExecute, execute);
    
    public DelegateCommand(Action<object> execute) : this(null, execute) { }
    
    public event EventHandler? CanExecuteChanged;
    
    public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    public bool CanExecute(object? parameter) => this._canExecute?.Invoke(parameter) ?? true;    

    public void Execute(object? parameter) => this._execute?.Invoke(parameter);
}