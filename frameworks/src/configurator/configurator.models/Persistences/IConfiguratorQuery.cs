using Mov.Core.Repositories.Services.Cruds;

namespace Mov.Configurator.Models.Persistences
{
    public interface IConfiguratorQuery
    {
        IPersistenceQuery<UserSetting> UserSetting { get; }
    }
}