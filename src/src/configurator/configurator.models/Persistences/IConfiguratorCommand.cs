using Mov.Repositories.Services.Cruds;

namespace Mov.Configurator.Models.Persistences
{
    public interface IConfiguratorCommand
    {
        IPersistenceCommand<UserSetting> UserSetting { get; }
    }
}