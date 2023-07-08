using Mov.Configurator.Models.Entities;
using Mov.Core.Templates.Crud;

namespace Mov.Configurator.Models.Persistences
{
    public interface IConfiguratorQuery
    {
        IPersistenceQuery<UserSettingSchema> UserSetting { get; }
    }
}