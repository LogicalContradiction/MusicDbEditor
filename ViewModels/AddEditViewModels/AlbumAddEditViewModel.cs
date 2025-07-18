﻿using MusicDbEditor.Commands;
using MusicDbEditor.Models;
using MusicDbEditor.ViewModels.DataViewModels;
using System.Windows;
using System.Windows.Input;

namespace MusicDbEditor.ViewModels.AddEditViewModels
{
    /// <summary>
    /// View Model for the AlbumAddEditWindow.
    /// </summary>
    public class AlbumAddEditViewModel
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

        #region Commands

        /// <summary>
        /// Command to close the window
        /// </summary>
        public ICommand CloseWindowCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="album">The album that is being edited.
        /// Null if a new album is being created.</param>
        public AlbumAddEditViewModel(AlbumViewModel album, Action closeAction) 
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

            CloseWindowCommand = new RelayCommand(closeAction);


        }

        #endregion

    }
}
