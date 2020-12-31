using Scale4Web.Core;
using Scale4Web.Core.ConversionSettings;
using Scale4Web.Core.Providers;
using Scale4Web.Modules.ViewModels;
using Scale4Web.Ui.Navigation;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace Scale4Web.Startup
{
    internal class Bootstrap
    {
        public Serilog.Core.Logger GetLogger()
        {
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                        .CreateLogger();
            return logger;
        }

        public IUnityContainer BootstrapDI()
        {
            var container = new UnityContainer();

            container.RegisterType<IConfigurationReader, LegacyConfigurationReader>()
            .RegisterType<IConfigurationConverterFactory, ConfigurationConverterFactory>()
            .RegisterType<INavigationManager, NavigationManager>()
            .RegisterInstance<ILogger>(GetLogger())

            //modules and factory
            .RegisterType<IModule, ImageViewModel>(nameof(ImageViewModel))
            .RegisterFactory<Func<string, IModule>>((c) => new Func<string, IModule>(name => c.Resolve<IModule>(name)))
            //finally, register self
            .RegisterInstance(container);

            return container;
        }
    }
}
