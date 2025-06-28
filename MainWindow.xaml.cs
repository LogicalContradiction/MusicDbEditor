using MusicDbEditor.ViewModels;
using MusicDbEditor.ViewModels.DataViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicDbEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Bind the view models to the tabs
            trackTab.DataContext = new TrackTabViewModel();
            albumTab.DataContext = new AlbumTabViewModel();
        }
    }
}