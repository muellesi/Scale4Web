using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scale4Web.Core.ConversionSettings.Legacy;
using Unity;

namespace Scale4Web.Core.Providers
{
    class ConfigurationConverterFactory : IConfigurationConverterFactory
    {
        private IUnityContainer _container;

        public ConfigurationConverterFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IConfigurationConverter GetLegacyConverter()
        {
            return _container.Resolve<LegacyConfigurationConverter>();
        }
    }
}
