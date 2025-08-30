
using Microsoft.Extensions.DependencyInjection;
using MusicDbEditor.ViewModels.AddEditViewModels;
using MusicDbEditor.ViewModels.DataViewModels;
using MusicDbEditor.Views.AddEditViews;
using System.Windows;

namespace MusicDbEditor.Services
{
    internal class WindowManager : WindowManagerInterface
    {
        #region Album Methods

        public bool OpenAddAlbumWindow(ServiceProvider serviceProvider)
        {
            OpenAddEditWindow(null, serviceProvider);
            return true;
        }

        public bool OpenEditAlbumWindow(AlbumViewModel albumViewModel, ServiceProvider serviceProvider)
        {
            OpenAddEditWindow(albumViewModel, serviceProvider);
            return true;
        }

        #region Private Album Helper Methods

        /// <summary>
        /// Opens a window to add or edit an album.
        /// </summary>
        /// <param name="albumViewModel">If editing, the view model of the album being edited.
        /// If adding a new entry, null.</param>
        /// <param name="serviceProvider">The service provider used to get services.</param>
        private void OpenAddEditWindow(AlbumViewModel albumViewModel, ServiceProvider serviceProvider)
        {
            // Create the add/edit window
            Window window = new AlbumAddEditWindow(albumViewModel);

            // Set the data context
            window.DataContext = new AlbumAddEditViewModel(albumViewModel, () => {window.Close(); }, serviceProvider);

            // Show the window
            window.Show();
        }

        #endregion

        #endregion

        #region Source Media Methods

        public bool OpenAddSourceMediaWindow(ServiceProvider serviceProvider)
        {
            OpenAddEditSourceMediaWindow(null, serviceProvider);
            return true;
        }

        public bool OpenEditSourceMediaWindow(SourceMediaViewModel sourceMediaViewModel, ServiceProvider serviceProvider)
        {
            OpenAddEditSourceMediaWindow(sourceMediaViewModel, serviceProvider);
            return true;
        }


        #region Private Source Media Helper Methods

        /// <summary>
        /// Private helper method to open a window to add or edit a source media.
        /// </summary>
        /// <param name="sourceMediaViewModel">If editing, the view model of the source media being edited.
        /// If adding a new entry, null.</param>
        /// <param name="serviceProvider">The service provider used to get services.</param>
        private void OpenAddEditSourceMediaWindow(SourceMediaViewModel sourceMediaViewModel, ServiceProvider serviceProvider)
        {
            // Create the add/edit window
            Window window = new SourceMediaAddEditWindow(sourceMediaViewModel);

            // set the data context
            window.DataContext = new SourceMediaAddEditViewModel(sourceMediaViewModel, () => { window.Close(); }, serviceProvider);

            window.Show();
        }


        #endregion

        #endregion
    }
}
