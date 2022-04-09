using Mov.Accessors;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    AppSettings = new AppSettingRepository(new JsonFileHelper(Path.Combine(path, AppSettingRepository.FILE_NAME), encode));
                    Variables = new VariableRepository(new JsonFileHelper(Path.Combine(path, VariableRepository.FILE_NAME), encode));
                    break;
                case FileType.Xml:
                    UserSettings = new UserSettingRepository(new XmlFileHelper(Path.Combine(path, UserSettingRepository.FILE_NAME), encode));
                    AppSettings = new AppSettingRepository(new XmlFileHelper(Path.Combine(path, AppSettingRepository.FILE_NAME), encode));
                    Variables = new VariableRepository(new XmlFileHelper(Path.Combine(path, VariableRepository.FILE_NAME), encode));
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        public IUserSettingRepository UserSettings { get; }
        public IAppSettingRepository AppSettings { get; }
        public IVariableRepository Variables { get; }

    }
}
