using Mov.Configurator.Models.Entities;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorEngine
    {
        ErrorSchema GetError(string param);

        ParameterSchema GetSchema(string param);

        UserSettingSchema GetUserSetting(string param);
    }
}