using System;
using System.Windows.Input;

namespace ICommandImpl {
    public class ListWindowsCommand : ICommand {
        private readonly Func<bool> canExecute;

        private readonly Action action;

        public ListWindowsCommand(Func<bool> canExecute, Action action) {
            this.canExecute = canExecute;
            this.action = action;
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        #region ICommand

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? param) => canExecute();

        public void Execute(object? param) => action();

        #endregion
    }
}