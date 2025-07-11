using MusicDbEditor.Models;
using MusicDbEditor.Views;
using System.Windows.Input;

namespace MusicDbEditor.Commands
{
    class AddEditAlbumCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            new AlbumAddEditWindow(new Album()
            {
                Id = 7,
                Name = "Album Name",
                SortName = "album name",
                DatabaseLink = "Album Name Database Link",
                PurchaseLink = "Album Name Purchase Link"
            }
            ).Show();
        }
    }
}
