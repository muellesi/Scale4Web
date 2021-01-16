using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scale4Web.Core.ConversionSettings.Default
{
    class DummyDefaultConfigurationReader : ISpecificConfigurationReader
    {
        public string ConfigFileName => "";

        public Version Version => new Version("99.0");

        public bool CanRead()
        {
            return true;
        }

        public Task<ConversionSettings> TryReadConfig()
        {
            var defaultGuid = Guid.NewGuid();

            return Task.FromResult(
                new ConversionSettings
                {
                    AppVersion = GetType().Assembly.GetName().Version,
                    Presets = new List<ConversionPreset>
                    {
                        new() {
                          Name =  "Gallery Image",
                          Quality =  75,
                          MaxOutputHeight =  500,
                          MaxOutputWidth =  500,
                          EnforceDimensions = false,
                          OutputFormat = OutputFileType.JPG,
                          ResizeStrategy = ResizeStrategy.Scale,
                          Guid =  Guid.NewGuid()
                        },
                        new() {
                          Name =  "Portrait",
                          Quality =  80,
                          MaxOutputHeight =  300,
                          MaxOutputWidth =  300,
                          EnforceDimensions = false,
                          OutputFormat = OutputFileType.JPG,
                          ResizeStrategy = ResizeStrategy.Scale,
                          Guid =  Guid.NewGuid()
                        },
                        new() {
                          Name =  "Passport Photo",
                          Quality =  80,
                          MaxOutputHeight =  300,
                          MaxOutputWidth = "Auto",
                          EnforceDimensions = false,
                          OutputFormat = OutputFileType.JPG,
                          ResizeStrategy = ResizeStrategy.Scale,
                          Guid =  Guid.NewGuid()
                        },
                        new() {
                          Name =  "Single Image",
                          Quality =  80,
                          MaxOutputHeight = "Auto",
                          MaxOutputWidth =  600,
                          EnforceDimensions = false,
                          OutputFormat = OutputFileType.JPG,
                          ResizeStrategy = ResizeStrategy.Scale,
                          Guid =  defaultGuid
                        }
                    },
                    DefaultPreset = defaultGuid,
                }
            );
        }
    }
}
