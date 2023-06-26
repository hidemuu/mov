using Mov.Repositories.Services;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorRepository : IDomainRepository
    {
        IDbObjectRepository<UserSetting, UserSettingCollection> UserSettings { get; }

    }
}