using Microsoft.Extensions.DependencyInjection;
using MusicDbEditor.Commands;
using MusicDbEditor.Services;
using MusicDbEditor.ViewModels.DataViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MusicDbEditor.ViewModels.TabViewModels
{
    internal class SourceMediaTabViewModel : INotifyPropertyChanged
    {
        #region Interface Methods

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion

        #region Properties

        /// <summary>
        /// The collection of Source Medias to show the user.
        /// </summary>
        public ObservableCollection<SourceMediaViewModel> SourceMedias { get; set; }

        /// <summary>
        /// Private backing field for SelectedSourceMediaViewModel
        /// </summary>
        private SourceMediaViewModel _selectedSourceMediaViewModel;

        /// <summary>
        /// The Source Media that is currently selected by the user.
        /// </summary>
        public SourceMediaViewModel SelectedSourceMediaViewModel
        {
            get { return _selectedSourceMediaViewModel; }

            set
            {
                // new value is the same as the old one, don't change
                if (value == _selectedSourceMediaViewModel) return;
                this._selectedSourceMediaViewModel = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(SelectedSourceMediaViewModel)));
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Command to run when editing a Source Media.
        /// </summary>
        public ICommand EditSourceMediaCommand { get; set; }

        /// <summary>
        /// Command to run when adding a Source Media.
        /// </summary>
        public ICommand AddSourceMediaCommand { get; set; }

        #endregion

        #region Constructor

        public SourceMediaTabViewModel(ServiceProvider serviceProvider)
        {
            var dataService = serviceProvider.GetService<DataConnectionInterface>();
            var data = dataService.GetSourceMediaData().Select(sourceMedia => new SourceMediaViewModel(sourceMedia));

            // put the data in the view model
            this.SourceMedias = new ObservableCollection<SourceMediaViewModel>(data);

            // get the window manager
            var windowManager = serviceProvider.GetService<WindowManagerInterface>();

            EditSourceMediaCommand = new RelayCommandConditional(() => { windowManager.OpenEditSourceMediaWindow(SelectedSourceMediaViewModel, serviceProvider); });
            AddSourceMediaCommand = new RelayCommand(() => { windowManager.OpenAddSourceMediaWindow(serviceProvider); });

        }

        #endregion







    }
}
