
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
        public AlbumTabViewModel(ServiceProvider serviceProvider)
        {
            // get the data from the DataConnection and put them into viewmodels
            var dataService = serviceProvider.GetService<DataConnectionInterface>();
            var data = dataService.GetAlbumData().Select(album => new AlbumViewModel(album));

            // put the data in this viewmodel
            this.Albums = new ObservableCollection<AlbumViewModel>(data);

            // get the windowmanager
            var windowManager = serviceProvider.GetService<WindowManagerInterface>();

            EditAlbumCommand = new RelayCommandConditional(() => { windowManager.OpenEditAlbumWindow(SelectedAlbumViewModel); });
            AddAlbumCommand = new RelayCommand(() => { windowManager.OpenAddAlbumWindow(); });

        
        }

        #endregion

    }
}
