using Scale4Web.Core.ConversionSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Scale4Web.Core.Util.Json
{
    public class JsonImageSideLengthConverter : JsonConverter<ImageSideLength>
    {
        private const string AUTO_STRING = "Auto";

        public override bool CanConvert(Type typeToConvert)
        {
            return
                typeToConvert == typeof(ImageSideLength) || typeToConvert == typeof(string) || IsSupportedNumberFormat(typeToConvert);
        }

        public override ImageSideLength Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (typeToConvert == typeof(string))
            {
                var input = reader.GetString();
                if (input.ToLower() != AUTO_STRING.ToLower())
                {
                    throw new InvalidCastException();
                }
                return ImageSideLength.Auto;
            }
            else if (typeToConvert == typeof(int))
            {
                return new ImageSideLength { IsAuto = false, SideLength = reader.GetInt32() };
            }
            else if (typeToConvert == typeof(double))
            {
                return new ImageSideLength { IsAuto = false, SideLength = (int)reader.GetDouble() };
            }
            else if (typeToConvert == typeof(decimal))
            {
                return new ImageSideLength { IsAuto = false, SideLength = (int)reader.GetDecimal() };
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, ImageSideLength value, JsonSerializerOptions options)
        {
            if (value.IsAuto || !value.SideLength.HasValue)
            {
                writer.WriteStringValue(AUTO_STRING);
            }
            else
            {
                writer.WriteNumberValue(value.SideLength.Value);
            }
        }

        private bool IsSupportedNumberFormat(Type typeToConvert)
        {
            return typeToConvert == typeof(int) || typeToConvert == typeof(double) || typeToConvert == typeof(decimal);
        }
    }
}
