﻿
using MusicDbEditor.Commands;
using MusicDbEditor.ViewModels.AddEditViewModels;
using MusicDbEditor.ViewModels.DataViewModels;
using MusicDbEditor.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace MusicDbEditor.ViewModels.TabViewModels
{
    /// <summary>
    /// View model to represent the album tab
    /// </summary>
    class AlbumTabViewModel : INotifyPropertyChanged
    {
        #region Interface Methods

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion


        #region Properties

        /// <summary>
        /// The collection of albums to show to the user
        /// </summary>
        public ObservableCollection<AlbumViewModel> Albums { get; set; }

        /// <summary>
        /// Private backing field for SelectedAlbumViewModel.
        /// </summary>
        private AlbumViewModel _album;

        /// <summary>
        /// The currently selected album view model.
        /// </summary>
        public AlbumViewModel SelectedAlbumViewModel 
        {
            get 
            {
                return _album;
            }

            set
            {
                // new value is the same as old. No need to change it.
                if (value == _album) return;
                
                this._album = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(SelectedAlbumViewModel)));
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Command to run when editing an Album.
        /// </summary>
        public ICommand EditAlbumCommand { get; set; }

        /// <summary>
        /// Command to run when adding an Album.
        /// </summary>
        public ICommand AddAlbumCommand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public AlbumTabViewModel() 
        {
            // get the data from the DataConnection and put them into viewmodels
            var data = DataConnection.Instance.GetAlbumData().Select(album => new AlbumViewModel(album));

            // put the data in this viewmodel
            this.Albums = new ObservableCollection<AlbumViewModel>(data);

            EditAlbumCommand = new RelayCommandConditional(OpenEditWindow);
            AddAlbumCommand = new RelayCommand(OpenAddWindow);
        
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Opens the AddEdit window for Album.
        /// </summary>
        /// <param name="albumViewModel">The current selected album if editing.
        /// Null if a new album.</param>
        private void OpenAddEditWindow(AlbumViewModel albumViewModel)
        {
            // Create the add/edit window
            Window window = new AlbumAddEditWindow(albumViewModel);

            // Set the data context
            //window.DataContext = new AlbumAddEditViewModel(albumViewModel);

            // Show the window
            window.Show();
        }

        /// <summary>
        /// Sets the album for the AddEditWindow to be the currently selected album.
        /// </summary>
        private void OpenAddWindow()
        {
            OpenAddEditWindow(null);
        }

        /// <summary>
        /// Sets the album for the AddEditWindow to null (to add a new album).
        /// </summary>
        private void OpenEditWindow()
        {
            OpenAddEditWindow(SelectedAlbumViewModel);
        }

        #endregion
    }
}
