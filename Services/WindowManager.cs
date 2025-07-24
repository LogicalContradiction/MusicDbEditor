
using MusicDbEditor.ViewModels.AddEditViewModels;
using MusicDbEditor.ViewModels.DataViewModels;
using MusicDbEditor.Views;
using System.Windows;

namespace MusicDbEditor.Services
{
    internal class WindowManager : WindowManagerInterface
    {
        #region Album Methods

        public void OpenAddWindow()
        {
            OpenAddEditWindow(null);
        }

        public void OpenEditWindow(AlbumViewModel albumViewModel)
        {
            OpenAddEditWindow(albumViewModel);
        }

        #region Private Album Helper Methods

        /// <summary>
        /// Opens a window to add or edit an album.
        /// </summary>
        /// <param name="albumViewModel"></param>
        private void OpenAddEditWindow(AlbumViewModel albumViewModel)
        {
            // Create the add/edit window
            Window window = new AlbumAddEditWindow(albumViewModel);

            // Set the data context
            window.DataContext = new AlbumAddEditViewModel(albumViewModel, () => {window.Close(); });

            // Show the window
            window.Show();
        }

        #endregion

        #endregion
    }
}
