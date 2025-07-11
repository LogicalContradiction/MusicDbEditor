using MusicDbEditor.Models;
using MusicDbEditor.ViewModels.NewElementViewModels;
using System.Windows;

namespace MusicDbEditor.Views
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
        public AlbumAddEditWindow(Album album)
        {
            InitializeComponent();

            this.DataContext = new NewAlbumViewModel(album);

            // If album isn't null, we are editing an existing album details.
            if (album != null) SetFields(album);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Set the text fields of the window in order to edit the album.
        /// </summary>
        /// <param name="album">The album that is being edited.</param>
        private void SetFields(Album album)
        {
            this.NameTextBox.Text = album.Name;
            this.SortNameTextBox.Text = album.SortName;
            this.DatabaseLinkTextBox.Text = album.DatabaseLink;
            this.PurchaseLinkTextBox.Text = album.PurchaseLink;
        }

        #endregion
    }
}
