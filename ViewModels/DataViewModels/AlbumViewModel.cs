
using MusicDbEditor.Models;

namespace MusicDbEditor.ViewModels.TabViewModels
{
    /// <summary>
    /// View model representing album data
    /// </summary>
    class AlbumViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// The album this view model represents
        /// </summary>
        private Album Album { get; set; }

        /// <summary>
        /// The name of this album
        /// </summary>
        public string Name 
        { 
            get
            {
                return Album.Name;
            }
            set
            {
                Album.Name = value;
            }
                
        }

        /// <summary>
        /// The sort name of this album
        /// </summary>
        public string SortName
        {
            get
            {
                return Album.SortName;
            }
            set
            {
                Album.SortName = value;
            }
        }

        /// <summary>
        /// Link to a database with info about this album
        /// </summary>
        public string DatabaseLink
        {
            get
            {
                return Album.DatabaseLink;
            }
            set
            {
                Album.DatabaseLink = value;
            }
        }

        /// <summary>
        /// Link to purchase this album
        /// </summary>
        public string PurchaseLink
        {
            get
            {
                return Album.PurchaseLink;
            }
            set
            {
                Album.PurchaseLink = value;
            }

        }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an AlbumViewModel representing the provided album
        /// </summary>
        /// <param name="album"></param>
        public AlbumViewModel(Album album)
        {
            Album = album;
        }

        #endregion

    }
}
