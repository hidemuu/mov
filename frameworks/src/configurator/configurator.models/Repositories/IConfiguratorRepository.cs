using Mov.Core.Templates.Repositories;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorRepository : IDomainRepository
    {
        IDbObjectRepository<UserSetting, UserSettingCollection> UserSettings { get; }
    }
}