using Scale4Web.Core.Util.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Windows;

namespace Scale4Web.Core.ConversionSettings
{
    public enum OutputFileType
    {
        JPG = 0,
        PNG = 1
    }

    public enum ResizeStrategy
    {
        Scale = 0,
        Crop
    }

    [JsonConverter(typeof(JsonImageSideLengthConverter))]
    public class ImageSideLength
    {
        public static ImageSideLength Auto
        {
            get { return new ImageSideLength { IsAuto = true, SideLength = null }; }
        }

        public bool IsAuto { get; set; }

        public int? SideLength { get; set; }

        public static implicit operator ImageSideLength(int i) => new ImageSideLength { IsAuto = false, SideLength = i };

        public static implicit operator ImageSideLength(double i) => new ImageSideLength { IsAuto = false, SideLength = (int)i };

        public static implicit operator ImageSideLength(decimal i) => new ImageSideLength { IsAuto = false, SideLength = (int)i };

        public static implicit operator ImageSideLength(string s)
        {
            if (s.ToLower() == "auto")
            {
                return new ImageSideLength { IsAuto = true, SideLength = null };
            }

            throw new ArgumentException($"{nameof(ImageSideLength)} can only be initialized to a number or \"[A|a]uto\"!");
        }

        public override string ToString()
        {
            return IsAuto ? "Auto" : SideLength.ToString();
        }
    }

    public class ConversionPreset
    {
        public string Name { get; set; }

        public Guid Guid { get; set; }

        public OutputFileType OutputFormat { get; set; }

        public double Quality { get; set; }

        public ResizeStrategy ResizeStrategy { get; set; }

        public ImageSideLength MaxOutputWidth { get; set; }

        public ImageSideLength MaxOutputHeight { get; set; }

        public bool EnforceDimensions { get; set; }

        public override string ToString()
        {
            return $"{Name} ({MaxOutputWidth} x {MaxOutputHeight})";
        }
    }


    public class ConversionSettings : IConversionSettings
    {
        public ConversionSettings()
        {
            Presets = new List<ConversionPreset>();
        }

        public List<ConversionPreset> Presets { get; init; }

        public Guid DefaultPreset { get; set; }

        public Version AppVersion { get; set; }
    }
}