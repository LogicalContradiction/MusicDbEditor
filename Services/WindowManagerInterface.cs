

using MusicDbEditor.ViewModels.DataViewModels;

namespace MusicDbEditor.Services
{
    /// <summary>
    /// Defines methods used to implement window-related methods
    /// </summary>
    internal interface WindowManagerInterface
    {
        #region Album Methods

        /// <summary>
        /// Opens a window to add a new album info.
        /// </summary>
        public void OpenAddWindow();

        /// <summary>
        /// Opens a window to edit an existing album info.
        /// </summary>
        /// <param name="albumViewModel">The album whose data is being edited.</param>
        public void OpenEditWindow(AlbumViewModel albumViewModel);

        #endregion




    }
}
