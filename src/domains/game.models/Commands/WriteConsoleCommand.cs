﻿using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using Mov.Controllers;
using Mov.Game.Models;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models.Commands
{
    internal class WriteConsoleCommand : ICommand<IGameService, CommandResponse>
    {
        public string Name => GameCommands.WriteConsole.ToString();

        public string ShortName => "wc";

        public CommandResponse Invoke(IGameService service, string[] args)
        {
            Console.WriteLine(service.Repository.Landmarks.ToString());
            return CommandResponse.Success;
        }

        public string Help()
        {
            return "コンソールに書き込む";
        }
    }
}