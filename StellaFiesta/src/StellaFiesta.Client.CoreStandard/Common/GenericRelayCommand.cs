using System;
using System.Diagnostics;
using System.Windows.Input;

namespace StellaFiesta.Client.CoreStandard
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }

            var arg = (T)parameter;
            return canExecute(arg);
        }

        public void Execute(object parameter)
        {
            var arg = (T)parameter;
            execute(arg);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
