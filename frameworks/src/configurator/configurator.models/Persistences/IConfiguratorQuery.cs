using Mov.Core.Templates.Crud;

namespace Mov.Configurator.Models.Persistences
{
    public interface IConfiguratorQuery
    {
        IPersistenceQuery<UserSetting> UserSetting { get; }
    }
}