using Scale4Web.Core.ConversionSettings;
using Scale4Web.i18n;
using Scale4Web.Modules.ViewModels;
using Scale4Web.Modules.Views;
using Scale4Web.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Windows;
using Unity;

namespace Scale4Web
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        const string LEGACY_CONFIG_FILENAME = "settings.json";
        const string CONFIG_FILENAME = "settings.json";

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var test = Strings.Test;

            var container = new Bootstrap().BootstrapDI();

            //configuration
            var dynamicConfigReader = container.Resolve<DynamicConfigurationReader>();
            var config = await dynamicConfigReader.TryReadConfig();
            container.RegisterInstance(config);

            MainWindowViewModel mainVm = container.Resolve<MainWindowViewModel>();
            var mainWindow = new MainWindow() { DataContext = mainVm };

            mainWindow.Show();
        }
    }
}
