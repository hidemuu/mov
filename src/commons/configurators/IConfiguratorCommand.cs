﻿using Mov.Configurator.Models.Schemas;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorCommand
    {
        ISave<UserSettingSchema> UserSettingSaver { get; }

        IDelete<UserSettingSchema> UserSettingDeleter { get; }

    }
}