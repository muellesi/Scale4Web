using Scale4Web.Core.ConversionSettings;
using Scale4Web.Util;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace Scale4Web.Core
{
    public class LegacyConfigurationConverter : IConfigurationConverter
    {
        public Task<ConversionSettings.ConversionSettings> Convert(object otherFormat)
        {
            var converted = new ConversionSettings.ConversionSettings();

            if (otherFormat is LegacyConfig input)
            {
                foreach (var preset in input.presets)
                {

                    ImageSideLength outputHeight;
                    ImageSideLength outputWidth;

                    switch (preset.limitSide)
                    {
                        default:
                        case LegacyConfig.SideSetting.Longest:
                            outputWidth = preset.selectedSideMaxLength;
                            outputHeight = preset.selectedSideMaxLength;
                            break;

                        case LegacyConfig.SideSetting.Width:
                            outputHeight  = ImageSideLength.Auto;
                            outputWidth = preset.selectedSideMaxLength;
                            break;

                        case LegacyConfig.SideSetting.Height:
                            outputWidth = ImageSideLength.Auto;
                            outputHeight = preset.selectedSideMaxLength;
                            break;
                    }

                    var convertedPreset = new ConversionPreset
                    {
                        Name = preset.name,
                        Guid = preset.id.ToGuid(),
                        OutputFormat = OutputFileType.JPG,
                        Quality = preset.quality,
                        ResizeStrategy = ResizeStrategy.Scale,
                        MaxOutputHeight = outputHeight,
                        MaxOutputWidth = outputWidth,
                        EnforceDimensions = false
                    };


                    converted.AppVersion = GetType().Assembly.GetName().Version;
                    converted.Presets.Add(convertedPreset);
                }
            }

            return Task.FromResult(converted);
        }
    }
}