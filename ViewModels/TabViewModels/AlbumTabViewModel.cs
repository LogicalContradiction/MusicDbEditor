
using Microsoft.Extensions.DependencyInjection;
using MusicDbEditor.Commands;
using MusicDbEditor.Services;
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


        #region Public Properties

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

        #region Private Properties

        private ServiceProvider Services;

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
        /// <param name="serviceProvider">Service provider used to get any needed service.</param>
        public AlbumTabViewModel(ServiceProvider serviceProvider)
        {
            // save a reference to the service provider
            Services = serviceProvider;

            Albums = new ObservableCollection<AlbumViewModel>();

            // Load the data into the ObservableList
            RefreshAlbumInfo();

            // get the windowmanager
            var windowManager = serviceProvider.GetService<WindowManagerInterface>();

            EditAlbumCommand = new RelayCommandConditional(() => { windowManager.OpenEditAlbumWindow(SelectedAlbumViewModel, serviceProvider, RefreshAlbumInfo); });
            AddAlbumCommand = new RelayCommand(() => { windowManager.OpenAddAlbumWindow(serviceProvider, RefreshAlbumInfo); });

        
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Refreshes the data in the Albums ObservableList.
        /// </summary>
        internal void RefreshAlbumInfo()
        {
            // get the data service
            var dataService = Services.GetService<DataConnectionInterface>();
            // get the data from the service
            var data = dataService.GetAlbumData().Select(album => new AlbumViewModel(album));
            // put it into the viewmodel
            Albums.Clear();
            foreach(var albumViewModel in data) Albums.Add(albumViewModel);

        }

        #endregion

    }
}
