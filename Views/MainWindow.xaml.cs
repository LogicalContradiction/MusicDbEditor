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
        public MainWindow()
        {
            InitializeComponent();

            // Create window manager
            WindowManagerInterface windowManager = new WindowManager();

            // Bind the view models to the tabs
            trackTab.DataContext = new TrackTabViewModel();
            albumTab.DataContext = new AlbumTabViewModel(windowManager);
        }
    }
}