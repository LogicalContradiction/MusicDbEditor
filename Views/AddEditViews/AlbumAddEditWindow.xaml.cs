using MusicDbEditor.Models;
using MusicDbEditor.ViewModels.AddEditViewModels;
using MusicDbEditor.ViewModels.DataViewModels;
using System.Windows;

namespace MusicDbEditor.Views.AddEditViews
{
    /// <summary>
    /// Interaction logic for AlbumAddEditWindow.xaml
    /// </summary>
    public partial class AlbumAddEditWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="album">The album that is being edited.
        /// Null if a new album is being added.</param>
        public AlbumAddEditWindow(AlbumViewModel album)
        {
            InitializeComponent();
        }

        #endregion

    }
}
