using System;
using System.Threading.Tasks;

namespace Scale4Web.Core.ConversionSettings
{
    public interface IConfigurationReader
    {
        Task<ConversionSettings> TryReadConfig();
    }

    public interface ISpecificConfigurationReader : IConfigurationReader
    {
        string ConfigFileName { get; }

        Version Version { get; }

        bool CanRead();
    }
}