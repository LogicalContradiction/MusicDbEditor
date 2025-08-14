using MusicDbEditor.Models;
using System.ComponentModel;

namespace MusicDbEditor.ViewModels.DataViewModels
{
    class SourceMediaViewModel : INotifyPropertyChanged
    {
        #region Interface Methods

        public event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };

        #endregion

        #region Properties

        /// <summary>
        /// The Source Media this view model represents
        /// </summary>
        private SourceMedia SourceMedia { get; set; }

        /// <summary>
        /// The Name of this Source Media
        /// </summary>
        public string Name
        {
            get
            {
                return SourceMedia.Name;
            }
            set
            {
                SourceMedia.Name = value;
            }
        }

        /// <summary>
        /// The Sort Name of this Source Media
        /// </summary>
        public string SortName
        {
            get
            {
                return SourceMedia.SortName;
            }
            set
            {
                SourceMedia.SortName = value;
            }
        }

        /// <summary>
        /// Boolean to check if the Name isn't null or an empty string.
        /// Used to determine if a tooltip needs to be shown.
        /// </summary>
        public bool HasName
        {
            get
            {
                return !String.IsNullOrEmpty(Name);
            }
        }

        /// <summary>
        /// Boolean to check if the SortName isn't null or an empty string.
        /// Used to determine if a tooltip needs to be shown.
        /// </summary>
        public bool HasSortName
        {
            get
            {
                return !String.IsNullOrEmpty(SortName);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sourceMedia">The Source Media this view model represents.</param>
        public SourceMediaViewModel(SourceMedia sourceMedia)
        {
            SourceMedia = sourceMedia;
        }

        #endregion

    }
}
