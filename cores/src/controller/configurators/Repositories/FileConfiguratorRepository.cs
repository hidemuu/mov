﻿using Mov.Core.Accessors.Models;
using Mov.Core.Configurators.Models.Schemas;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories.Services;
using System;
using System.IO;

namespace Mov.Core.Configurators.Repositories
{
    public class FileConfiguratorRepository : IConfiguratorRepository
    {
        #region property

        public IDbRepository<ApiSettingSchema, string, DbRequestSchemaString> ApiSettings { get; }

        public IDbRepository<UserSettingSchema, Guid, DbRequestSchemaString> UserSettings { get; }

        #endregion property

        #region constructor

        public FileConfiguratorRepository(string endpoint, FileType fileType, EncodingValue encoding)
        {
            ApiSettings = FileDbRepository<ApiSettingSchema, string>.Factory.Create(Path.Combine(endpoint, "api_setting.json"), fileType, encoding);
            UserSettings = FileDbRepository<UserSettingSchema, Guid>.Factory.Create(Path.Combine(endpoint, "user_setting.json"), fileType, encoding);
        }

        #endregion constructor
    }
}