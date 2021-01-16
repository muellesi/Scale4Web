using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Scale4Web.Core.ConversionSettings
{
    public class DynamicConfigurationReader
    {
        private ISpecificConfigurationReader _selectedBackend;
        private readonly IEnumerable<ISpecificConfigurationReader> _availableBackends;
        private readonly IConfigurationWriter _configurationWriter;

        public ConversionSettings Settings
        {
            get;
            private set;
        }

        public DynamicConfigurationReader(IEnumerable<ISpecificConfigurationReader> readers, IConfigurationWriter configurationWriter)
        {
            _availableBackends = readers.ToList();
            _configurationWriter = configurationWriter;
        }

        public async Task<ConversionSettings> TryReadConfig()
        {
            var orderedBackends = _availableBackends
                .OrderBy(b => b.Version).ToList();
            _selectedBackend ??= orderedBackends
                .First(b => b.CanRead());

            Settings = await _selectedBackend.TryReadConfig().ConfigureAwait(false);
            return Settings;
        }
    }
}
