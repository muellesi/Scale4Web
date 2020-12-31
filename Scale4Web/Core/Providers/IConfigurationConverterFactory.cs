namespace Scale4Web.Core.Providers
{
    public interface IConfigurationConverterFactory
    {
        IConfigurationConverter GetLegacyConverter();
    }
}