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

    [Serializable]
    [JsonConverter(typeof(JsonImageSideLengthConverter))]
    public class ImageSideLength
    {
        public static ImageSideLength Auto
        {
            get { return new ImageSideLength { IsAuto = true, SideLength = null }; }
        }

        public bool IsAuto { get; set; }

        public int? SideLength { get; set; }

        public static implicit operator ImageSideLength(int i) => new ImageSideLength { IsAuto = false, SideLength = i};

        public static implicit operator ImageSideLength(double i) => new ImageSideLength { IsAuto = false, SideLength = (int)i };

        public static implicit operator ImageSideLength(decimal i) => new ImageSideLength { IsAuto = false, SideLength = (int)i };

    }

    [Serializable]
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

    }


    [Serializable]
    public class ConversionSettings : IConversionSettings
    {
        public ConversionSettings()
        {
            Presets = new List<ConversionPreset>();
            var test = GridLength.Auto;
        }


        public List<ConversionPreset> Presets { get; init; }

        public Version AppVersion { get; set; }
    }
}