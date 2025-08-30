using Microsoft.Extensions.DependencyInjection;
using MusicDbEditor.Commands;
using MusicDbEditor.ViewModels.DataViewModels;
using System.Windows.Input;

namespace MusicDbEditor.ViewModels.AddEditViewModels
{
    /// <summary>
    /// View Model for the SourceMediaAddEditWindow
    /// </summary>
    class SourceMediaAddEditViewModel
    {

        #region Properties

        /// <summary>
        /// The SourceMedia that is currently being edited.
        /// </summary>
        public SourceMediaViewModel SourceMedia { get; set; }

        /// <summary>
        /// The name of the Source Media being edited.
        /// </summary>
        public string NameEdit { get; set; }

        /// <summary>
        /// The sort name of the Source Media begin edited.
        /// </summary>
        public string SortNameEdit { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command to close the Window
        /// </summary>
        public ICommand CloseWindowCommand { get; set; }

        /// <summary>
        /// Command to write to the database and either add a new entry or edit an existing one.
        /// </summary>
        public ICommand AddEditRowCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="sourceMedia">The Source Media that is being edited. Null if the user wants to add a new one.</param>
        /// <param name="closeAction">An action used to close the window.</param>
        /// <param name="serviceProvider">Service provider used to get a service.</param>
        public SourceMediaAddEditViewModel(SourceMediaViewModel sourceMedia, Action closeAction, ServiceProvider serviceProvider)
        {
            if (sourceMedia != null)
            {
                // editing an existing Source, so set the Source Media
                SourceMedia = sourceMedia;

                // now set the properties
                NameEdit = sourceMedia.Name;
                SortNameEdit = sourceMedia.SortName;
            }

            // set the commands
            CloseWindowCommand = new RelayCommand(closeAction);
            //AddEditRowCommand = new RelayCommand();
        }

        #endregion



    }
}
