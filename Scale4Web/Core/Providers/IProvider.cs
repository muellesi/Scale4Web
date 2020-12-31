namespace Scale4Web.Core.Providers
{
    internal interface IProvider<T>
    {
        T Get();
    }
}