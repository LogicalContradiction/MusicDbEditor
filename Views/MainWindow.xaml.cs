using Microsoft.Extensions.DependencyInjection;
using MusicDbEditor.Services;
using MusicDbEditor.ViewModels.TabViewModels;
using System.Windows;

namespace MusicDbEditor.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ServiceProvider serviceProvider)
        {
            InitializeComponent();

            // Create window manager
            //WindowManagerInterface windowManager = new WindowManager();

            // Bind the view models to the tabs
            trackTab.DataContext = new TrackTabViewModel(serviceProvider);
            albumTab.DataContext = new AlbumTabViewModel(serviceProvider);
        }
    }
}