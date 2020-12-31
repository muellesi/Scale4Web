using System;
using System.Threading.Tasks;

namespace Scale4Web.Core.ConversionSettings
{
    public interface IConfigurationReader
    {
        Version Version { get; }

        IConversionSettings Settings { get; }

        string ConfigFileName { get; }

        Task<bool> TryReadConfig();
    }
}