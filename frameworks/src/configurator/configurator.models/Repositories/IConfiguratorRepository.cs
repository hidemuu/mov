using Mov.Configurator.Models.Entities;
using Mov.Core.Templates.Repositories;

namespace Mov.Configurator.Models.Repositories
{
    public interface IConfiguratorRepository : IDomainRepository
    {
        IDbObjectRepository<UserSetting, UserSettingCollection> UserSettings { get; }
    }
}