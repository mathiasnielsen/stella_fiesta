using System;

namespace StellaFiesta.Client.CoreStandard
{
    public class RelayCommand : RelayCommand<object>
    {
        public RelayCommand(Action execute)
            : this(execute, _ => true)
        {
        }

        public RelayCommand(Action<object> execute)
            : base(execute)
        {
        }

        public RelayCommand(Action execute, Predicate<object> canExecute)
            : base(_ => execute(), o => canExecute(o))
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
            : base(_ => execute(), _ => canExecute())
        {
        }
    }
}
