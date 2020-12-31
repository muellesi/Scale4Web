using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Serilog;
using Scale4Web.Core.ConversionSettings;
using Scale4Web.Core.Providers;

namespace Scale4Web.Core
{


    public class LegacyConfigurationReader : IConfigurationReader
    {
        private const string CONFIG_FILE_NAME = "settings.json";

        private readonly IConfigurationConverter _configConverter;
        private readonly ILogger _logger;

        public LegacyConfigurationReader(IConfigurationConverterFactory configConverterFactory, ILogger logger)
        {
            _configConverter = configConverterFactory.GetLegacyConverter();
            _logger = logger;
        }

        Version IConfigurationReader.Version => new(0, 0);

        public IConversionSettings Settings { get; private set; }

        public string ConfigFileName => CONFIG_FILE_NAME;

        async Task<bool> IConfigurationReader.TryReadConfig()
        {
            try
            {
                using var fileStream = File.OpenRead(ConfigFileName);
                var legacyConfig = await JsonSerializer.DeserializeAsync<LegacyConfig>(fileStream);

                Settings = await _configConverter.Convert(legacyConfig);

                return true;
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "Could not parse legacy configuration file {@configFile}", ConfigFileName);
                return false;
            }
        }
    }
}
