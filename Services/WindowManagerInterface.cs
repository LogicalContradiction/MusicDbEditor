

using Microsoft.Extensions.DependencyInjection;
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
        /// <param name="serviceProvider">The service provider to be used by the view model.</param>
        /// <param name="refreshData">Action used to refresh the data if a new entry is added.</param>
        public bool OpenAddAlbumWindow(ServiceProvider serviceProvider, Action refreshData);

        /// <summary>
        /// Opens a window to edit an existing album info.
        /// </summary>
        /// <param name="albumViewModel">The album whose data is being edited.</param>
        /// <param name="serviceProvider">The service provider to be used by the view model.</param>
        /// <param name="refreshData">Action used to refresh the data if a new entry is added.</param>
        public bool OpenEditAlbumWindow(AlbumViewModel albumViewModel, ServiceProvider serviceProvider, Action refreshData);

        #endregion

        #region Source Media Methods

        /// <summary>
        /// Opens a window to add a new source media.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public bool OpenAddSourceMediaWindow(ServiceProvider serviceProvider);

        /// <summary>
        /// Opens a window to edit an existing source media info.
        /// </summary>
        /// <param name="sourceMediaViewModel">The Source Media whose data is being edited.</param>
        /// <param name="serviceProvider">The service provider to be used by the view model.</param>
        /// <returns></returns>
        public bool OpenEditSourceMediaWindow(SourceMediaViewModel sourceMediaViewModel, ServiceProvider serviceProvider);

        #endregion




    }
}
