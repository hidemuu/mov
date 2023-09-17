namespace Mov.Core.Configurators
{
    public interface IConfiguratorService
    {
        IConfiguratorStoreQuery Query { get; }
    }
}
