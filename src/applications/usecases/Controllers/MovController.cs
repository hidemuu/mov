using Mov.Configurator.Service;
using Mov.Controllers;
using Mov.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.UseCases.Controllers
{
    public class MovController : IMovController
    {
        #region フィールド

        private readonly IMovEngine engine;
        private readonly IDictionary<DomainType, IController> domainControllers = new Dictionary<DomainType, IController>();
        private DomainType currentDomain;

        #endregion フィールド

        #region コンストラクター

        public MovController(IMovEngine engine)
        {
            this.engine = engine;
            var factory = new DomainControllerFactory("Commands");
            domainControllers.Add(DomainType.Config, factory.Create(this.engine.Service.Configurator));
            domainControllers.Add(DomainType.Game, factory.Create(this.engine.Service.Game));
            domainControllers.Add(DomainType.Driver, factory.Create(this.engine.Service.Driver));
        }

        #endregion コンストラクター

        #region メソッド

        public bool SetDomain(string domainTypeString)
        {
            if (TryGetDomainType(domainTypeString, out DomainType domainType))
            {
                this.currentDomain = domainType;
                return true;
            }
            return false;
        }

        public bool ExecuteDomainCommand(string command, string[] args)
        {
            return ExecuteCommand(this.currentDomain, command, args);
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
            return ExistsCommand(this.currentDomain, command);
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
            return GetCommandHelp(this.currentDomain);
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
            stringBuilder.Append(DomainType.Translate.ToString().ToLower() + " : " + "翻訳");
            return stringBuilder.ToString();
        }

        #endregion メソッド

        #region 内部メソッド

        private bool TryGetDomainType(string domainTypeString, out DomainType domainType)
        {
            return Enum.TryParse(domainTypeString, true, out domainType);
        }

        #endregion 内部メソッド

    }
}
