using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDbEditor.Commands
{
    internal class RelayCommandConditional : RelayCommand
    {
        public RelayCommandConditional(Action mAction) : base(mAction)
        {
        }

        public override bool CanExecute(object? parameter)
        {
            return parameter != null;
        }
    }
}
