using Mov.Accessors;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class ConfiguratorRepository : IConfiguratorRepository
    {
        public ConfiguratorRepository(string path, FileType fileType, string encode = "utf-8")
        {
            switch (fileType)
            {
                case FileType.Json:
                    UserSettings = new UserSettingRepository(new JsonFileHelper(Path.Combine(path, UserSettingRepository.FILE_NAME), encode));
                    break;
                default:
                    UserSettings = new UserSettingRepository(new XmlFileHelper(Path.Combine(path, UserSettingRepository.FILE_NAME), encode));
                    break;
            }
        }

        public IUserSettingRepository UserSettings { get; }

    }
}
