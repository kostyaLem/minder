using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Minder.Commands
{
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public virtual void Execute(object parameter)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
