
using MusicDbEditor.Commands;
using MusicDbEditor.ViewModels.DataViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MusicDbEditor.ViewModels.TabViewModels
{
    /// <summary>
    /// View model to represent the album tab
    /// </summary>
    class AlbumTabViewModel
    {
        #region Properties

        /// <summary>
        /// The collection of albums to show to the user
        /// </summary>
        public ObservableCollection<AlbumViewModel> Albums { get; set; }

        #endregion

        #region Commands

        public ICommand AddEditAlbumCommand { get; set; }

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

            AddEditAlbumCommand = new AddEditAlbumCommand();
        
        }

        #endregion

        #region Helper Methods

        private void OpenAddEditWindow()
        {

        }

        #endregion
    }
}
