using System.Windows.Input;

namespace MusicDbEditor.Commands
{
    class RelayCommand : ICommand
    {
        /// <summary>
        /// Event handler that fires when <see cref="CanExecute(object?)"/> changes.
        /// </summary>
        public event EventHandler? CanExecuteChanged = (sender, e) => { };

        /// <summary>
        /// The action to execute.
        /// </summary>
        private Action mAction;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mAction">The action to exectue.</param>
        public RelayCommand(Action mAction)
        {
            this.mAction = mAction;
        }
        
        /// <summary>
        /// Relay Command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>True</returns>
        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            mAction();
        }
    }
}
