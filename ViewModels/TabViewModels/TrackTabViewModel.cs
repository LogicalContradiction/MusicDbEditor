using System.Collections.ObjectModel;
using MusicDbEditor.ViewModels.DataViewModels;
using System.Windows.Input;

namespace MusicDbEditor.ViewModels.TabViewModels
{
    internal class TrackTabViewModel : BaseViewModel
    {
        /// <summary>
        /// The collection of tracks shown to the user.
        /// </summary>
        public ObservableCollection<TrackViewModel> Tracks { get; set; }

        public ICommand GetTrackDataCommand { get; set; }






        /// <summary>
        /// Default constructor.
        /// </summary>
        public TrackTabViewModel()
        {
            // Get the track data from the db and turn them into viewmodels
            var data = DataConnection.Instance.GetTrackData().Select(track => new TrackViewModel(track));

            // Put them in this viewmodel
            this.Tracks = new ObservableCollection<TrackViewModel>(data);

            
        }
    }
}
