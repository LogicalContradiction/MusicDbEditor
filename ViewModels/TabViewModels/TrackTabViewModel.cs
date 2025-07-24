using System.Collections.ObjectModel;
using MusicDbEditor.ViewModels.DataViewModels;
using System.Windows.Input;
using System.ComponentModel;
using MusicDbEditor.Services;

namespace MusicDbEditor.ViewModels.TabViewModels
{
    internal class TrackTabViewModel : INotifyPropertyChanged
    {
        #region Interface Methods

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion

        #region Properties

        /// <summary>
        /// The collection of tracks shown to the user.
        /// </summary>
        public ObservableCollection<TrackViewModel> Tracks { get; set; }

        #endregion

        #region Commands

        public ICommand GetTrackDataCommand { get; set; }

        #endregion




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
