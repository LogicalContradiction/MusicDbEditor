using MusicDbEditor.Models;
using MusicDbEditor.ViewModels.DataViewModels;

namespace MusicDbEditor.ViewModels.AddEditViewModels
{
    /// <summary>
    /// View Model for the AlbumAddEditWindow.
    /// </summary>
    internal class AlbumAddEditViewModel : BaseViewModel
    {

        #region Properties
        /// <summary>
        /// The Album view model that is currently being edited.
        /// </summary>
        public AlbumViewModel Album { get; set; }

        /// <summary>
        /// The name of the album being edited.
        /// </summary>
        public string NameEdit { get; set; }

        /// <summary>
        /// The sort name of the album being edited.
        /// </summary>
        public string SortNameEdit { get; set; }

        /// <summary>
        /// The database link of the album being edited.
        /// </summary>
        public string DatabaseLinkEdit { get; set; }

        /// <summary>
        /// The purchase link of the album being edited.
        /// </summary>
        public string PurchaseLinkEdit { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="album">The album that is being edited.
        /// Null if a new album is being created.</param>
        public AlbumAddEditViewModel(AlbumViewModel album) 
        { 
            if (album != null)
            {
                // Set the album 
                Album = album;

                // Set the properties
                NameEdit = album.Name;
                SortNameEdit = album.SortName;
                DatabaseLinkEdit = album.DatabaseLink;
                PurchaseLinkEdit = album.PurchaseLink;
            }
            


        }

        #endregion

    }
}
