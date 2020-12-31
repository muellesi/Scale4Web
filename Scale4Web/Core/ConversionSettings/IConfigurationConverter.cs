using System.Threading.Tasks;

namespace Scale4Web.Core
{
    public interface IConfigurationConverter
    {
        Task<ConversionSettings.ConversionSettings> Convert(object otherFormat);
    }
}