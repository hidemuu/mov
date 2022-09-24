using Mov.Accessors;
using Mov.Accessors.Repository;
using Mov.Analizer.Models;
using Mov.Configurator.Models;
using Mov.Configurator.Repository;
using Mov.Controllers;
using Mov.Designer.Models;
using Mov.Designer.Repository;
using Mov.Driver.Models;
using Mov.Framework;
using Mov.Game.Models;
using Mov.Translator.Models;
using Mov.UseCases;
using Mov.UseCases.Factories;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mov.ConsoleApp
{
    class Program
    {
        #region フィールド

        static IDomainRepositoryCollection<IConfiguratorRepository> configRepository;
        static IDomainRepositoryCollection<IDesignerRepository> designerRepository;
        static IDomainRepositoryCollection<IGameRepository> gameRepository;
        static IDomainRepositoryCollection<IDriverRepository> driverRepository;
        static IDomainRepositoryCollection<IAnalizerRepository> analizerRepository;
        static IDomainRepositoryCollection<ITranslatorRepository> translatorRepository;
        static IController domainController;

        private delegate void CommandHandler(IEnumerable<string> parameters);

        #endregion フィールド

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Mov!");
            //リポジトリ生成
            var fileRepositoryFactory = new FileDomainRepositoryCollectionFactory(PathCreator.GetResourcePath());
            configRepository = fileRepositoryFactory.Create<IConfiguratorRepository>(SerializeConstants.PATH_JSON);
            designerRepository = fileRepositoryFactory.Create<IDesignerRepository>(SerializeConstants.PATH_XML);
            gameRepository = fileRepositoryFactory.Create<IGameRepository>(SerializeConstants.PATH_JSON);
            driverRepository = fileRepositoryFactory.Create<IDriverRepository>(SerializeConstants.PATH_JSON);
            analizerRepository = fileRepositoryFactory.Create<IAnalizerRepository>(SerializeConstants.PATH_JSON);
            translatorRepository = fileRepositoryFactory.Create<ITranslatorRepository>(SerializeConstants.PATH_JSON);
            Console.WriteLine("ドメインを入力してください");
            Console.ReadKey();
            //コントローラー生成
            switch (Console.ReadLine() ?? string.Empty) 
            {
                case "config":
                    domainController = new DomainController(configRepository.DefaultRepository);
                    break;
                case "design":
                    domainController = new DomainController(designerRepository.DefaultRepository);
                    break;
                case "game":
                    domainController = new DomainController(gameRepository.DefaultRepository);
                    break;
                case "driver":
                    domainController = new DomainController(driverRepository.DefaultRepository);
                    break;
                case "analizer":
                    domainController = new DomainController(analizerRepository.DefaultRepository);
                    break;
                case "translator":
                    domainController = new DomainController(translatorRepository.DefaultRepository);
                    break;
                default:
                    domainController = new DomainController(configRepository.DefaultRepository);
                    break;
            }
            Console.WriteLine("コントローラーを生成しました");
            Console.WriteLine("----- コマンドリスト ------");
            Console.WriteLine(domainController.GetCommandHelp());
            Console.WriteLine("----- end ------");
            //コマンド処理開始
            while (true)
            {
                Console.Write("> ");
                if(!TryGetCommandParameter(Console.ReadLine() ?? string.Empty, out string command, out string[] parameters))
                {
                    Console.WriteLine("コマンドを入力してください");
                    continue;
                }
                if (!domainController.ExistsCommand(command))
                {
                    Console.WriteLine($"コマンドが登録されていません : {command}");
                }
                else
                {
                    domainController.ExecuteCommand(command, parameters);
                }
            }

        }

        #region メソッド

        static bool TryGetCommandParameter(string input, out string command, out string[] parameters)
        {
            var tokens = input.Split(' ');
            if (tokens.Length < 1)
            {
                command = string.Empty;
                parameters = new string[0];
                return false;
            }

            command = tokens.First();
            parameters = tokens.Skip(1).ToArray();
            return true;
        }

        #endregion メソッド
    }
}
