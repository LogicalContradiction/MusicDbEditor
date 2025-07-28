using Microsoft.Extensions.DependencyInjection;
using MusicDbEditor.Services;
using MusicDbEditor.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MusicDbEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Setup the service manager
            var serviceCollection = new ServiceCollection();

            // Register Services
            serviceCollection.AddSingleton<DataConnectionInterface, DataConnection>();
            serviceCollection.AddTransient<WindowManagerInterface, WindowManager>();

            // Build service Provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            Window mainWindow = new MainWindow(serviceProvider);
            mainWindow.Show();
        }






    }



}
