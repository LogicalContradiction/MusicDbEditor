using MusicDbEditor.Models;

namespace MusicDbEditor.ViewModels.NewElementViewModels
{
    internal class NewAlbumViewModel : BaseViewModel
    {

        #region Properties
        public Album Album { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="album">The album that is being edited.
        /// Null if a new album is being created.</param>
        public NewAlbumViewModel(Album album) 
        { 
            if (album != null) Album = album;

        }

        #endregion
    }
}
