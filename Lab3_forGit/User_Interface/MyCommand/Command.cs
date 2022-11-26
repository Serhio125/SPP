using System;
using System.Windows.Input;

namespace Lab3.MyCommand
{
    public class Command : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public Command(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        
        public void Execute(object parametr)
        {
            _execute(parametr);
        }
        public bool CanExecute(object parametr)
        {
            return _canExecute(parametr);
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}