using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Scale4Web.Core.Providers;
using Serilog;

namespace Scale4Web.Core.ConversionSettings.Legacy
{


    public class LegacyConfigurationReader : ISpecificConfigurationReader
    {
        private const string CONFIG_FILE_NAME = "settings.json";

        private readonly IConfigurationConverter _configConverter;
        private readonly ILogger _logger;

        public LegacyConfigurationReader(IConfigurationConverterFactory configConverterFactory, ILogger logger)
        {
            _configConverter = configConverterFactory.GetLegacyConverter();
            _logger = logger;
        }

        Version ISpecificConfigurationReader.Version => new(0, 0);

        public string ConfigFileName => CONFIG_FILE_NAME;

        async Task<Core.ConversionSettings.ConversionSettings> IConfigurationReader.TryReadConfig()
        {
            try
            {
                await using var fileStream = File.OpenRead(ConfigFileName);
                var legacyConfig = await JsonSerializer.DeserializeAsync<LegacyConfig>(fileStream);

                return await _configConverter.Convert(legacyConfig).ConfigureAwait(false); 
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "Could not parse legacy configuration file {@configFile}", ConfigFileName);
                return null;
            }
        }

        bool ISpecificConfigurationReader.CanRead()
        {
            var configFileExists = File.Exists(ConfigFileName);
           
            return configFileExists;
        }
    }
}
