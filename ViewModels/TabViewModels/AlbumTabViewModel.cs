
using MusicDbEditor.ViewModels.TabViewModels;
using System.Collections.ObjectModel;

namespace MusicDbEditor.ViewModels.DataViewModels
{
    /// <summary>
    /// View model to represent the album tab
    /// </summary>
    class AlbumTabViewModel
    {
        /// <summary>
        /// The collection of albums to show to the user
        /// </summary>
        public ObservableCollection<AlbumViewModel> Albums { get; set; }


        public AlbumTabViewModel() 
        {
            // get the data from the DataConnection and put them into viewmodels
            var data = DataConnection.Instance.GetAlbumData().Select(album => new AlbumViewModel(album));

            // put the data in this viewmodel
            this.Albums = new ObservableCollection<AlbumViewModel>(data);
        
        }


    }
}
