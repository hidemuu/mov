using Mov.Core.Commands;
using Mov.Framework;
using Mov.Framework.Models;
using Mov.Framework.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.UseCase.Controllers
{
    public class ConsoleAppController : IConsoleAppController
    {
        #region field

        private readonly IMovEngine engine;
        private readonly IDictionary<DomainType, IUiController> domainControllers = new Dictionary<DomainType, IUiController>();
        private DomainType currentDomain;

        #endregion field

        #region constructor

        public ConsoleAppController(IMovEngine engine)
        {
            this.engine = engine;
            var factory = new DomainControllerFactory("Commands");
            domainControllers.Add(DomainType.Game, factory.Create(this.engine.Service.Game));
        }

        #endregion constructor

        #region method

        public bool SetDomain(string domainTypeString)
        {
            if (TryGetDomainType(domainTypeString, out DomainType domainType))
            {
                currentDomain = domainType;
                return true;
            }
            return false;
        }

        public bool ExecuteDomainCommand(string command, string[] args)
        {
            return ExecuteCommand(currentDomain, command, args);
        }

        public bool ExecuteCommand(DomainType domainType, string command, string[] args)
        {
            return domainControllers[domainType].ExecuteCommand(command, args);
        }

        public bool ExecuteCommand(string domainTypeString, string command, string[] args)
        {
            if (TryGetDomainType(domainTypeString, out DomainType domainType))
            {
                return ExecuteCommand(domainType, command, args);
            }
            return false;
        }

        public bool ExistsDomainCommand(string command)
        {
            return ExistsCommand(currentDomain, command);
        }

        public bool ExistsCommand(DomainType domainType, string command)
        {
            return domainControllers[domainType].ExistsCommand(command);
        }

        public bool ExistsCommand(string domainTypeString, string command)
        {
            if (TryGetDomainType(domainTypeString, out DomainType domainType))
            {
                return ExistsCommand(domainType, command);
            }
            return false;
        }

        public string GetDomainCommandHelp()
        {
            return GetCommandHelp(currentDomain);
        }

        public string GetCommandHelp(DomainType domainType)
        {
            return domainControllers[domainType].GetCommandHelp();
        }

        public string GetCommandHelp(string domainTypeString)
        {
            if (TryGetDomainType(domainTypeString, out DomainType domainType))
            {
                return GetCommandHelp(domainType);
            }
            return string.Empty;
        }

        public string GetDomainHelp()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(DomainType.Analize.ToString().ToLower() + " : " + "アナライザー");
            stringBuilder.AppendLine(DomainType.Config.ToString().ToLower() + " : " + "コンフィグ");
            stringBuilder.AppendLine(DomainType.Design.ToString().ToLower() + " : " + "デザイン");
            stringBuilder.AppendLine(DomainType.Driver.ToString().ToLower() + " : " + "ドライバー");
            stringBuilder.AppendLine(DomainType.Game.ToString().ToLower() + " : " + "ゲーム");
            return stringBuilder.ToString();
        }

        #endregion method

        #region private method

        private bool TryGetDomainType(string domainTypeString, out DomainType domainType)
        {
            domainType = new DomainType(domainTypeString);
            return !domainType.IsEmpty();
        }

        #endregion private method
    }
}