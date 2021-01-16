using System;
using System.Windows.Input;

namespace Scale4Web.Ui.Commands
{
    public class DelegateCommand<T> : ICommand where T : class
    {
        private readonly Func<T, bool> _delCanExecute;
        private readonly Action<T> _delCommandImpl;

        public event EventHandler? CanExecuteChanged;

        public DelegateCommand(Action<T> commandImpl, Func<T, bool> canExecute = null)
        {
            _delCommandImpl = commandImpl;
            _delCanExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _delCanExecute?.Invoke(parameter as T) ?? true;
        }

        public void Execute(object? parameter)
        {
            _delCommandImpl?.Invoke(parameter as T);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public sealed class DelegateCommand : DelegateCommand<object>
    {
        public DelegateCommand(Action<object> commandImpl) : base(commandImpl)
        {
        }
    }
}