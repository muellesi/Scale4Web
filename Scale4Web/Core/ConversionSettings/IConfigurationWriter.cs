using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Scale4Web.Core.ConversionSettings.Legacy;
using Serilog;

namespace Scale4Web.Core.ConversionSettings
{
    public interface IConfigurationWriter
    {
        Task Write(ConversionSettings settings);
    }

    public class ConfigurationWriter : IConfigurationWriter
    {
        private const string CONFIG_FILE_NAME = "presets.json";

        private ILogger _logger;

        public string ConfigFileName => CONFIG_FILE_NAME;


        public ConfigurationWriter(ILogger logger)
        {
            _logger = logger;
        }

        public async Task Write(ConversionSettings settings)
        {
            try
            {
                await using var fileStream = File.OpenRead(ConfigFileName);
                await JsonSerializer.SerializeAsync(fileStream, settings);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Could not write configuration file {@configFile}", ConfigFileName);
            }
        }
    }
}