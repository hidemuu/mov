using Mov.Configurator.Models.Entities;
using Mov.Core.Templates.Crud;

namespace Mov.Configurator.Models.Persistences
{
    public interface IConfiguratorCommand
    {
        IPersistenceCommand<UserSettingSchema> UserSetting { get; }
    }
}