using Mov.Accessors;
using Mov.Accessors.Repository;
using Mov.Configurator.Models;
using Mov.Configurator.Repository;
using Mov.Controllers;
using Mov.Designer.Models;
using Mov.Designer.Repository;
using Mov.Driver.Models;
using Mov.Game.Models;
using Mov.UseCases;
using Mov.UseCases.Creators;
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
        static IController domainController;

        private delegate void CommandHandler(IEnumerable<string> parameters);

        #endregion フィールド

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Mov!");
            //リポジトリ生成
            var repositoryFactory = new FileDomainRepositoryCollectionFactory(PathCreator.GetResourcePath());
            configRepository = repositoryFactory.Create<IConfiguratorRepository>(SerializeConstants.PATH_JSON);
            designerRepository = repositoryFactory.Create<IDesignerRepository>(SerializeConstants.PATH_XML);
            gameRepository = repositoryFactory.Create<IGameRepository>(SerializeConstants.PATH_JSON);
            driverRepository = repositoryFactory.Create<IDriverRepository>(SerializeConstants.PATH_JSON);
            Console.ReadKey();
            Console.WriteLine("ドメインを入力してください");
            //コントローラー生成
            domainController = new DomainController(configRepository.Repositories[""]);

            //コマンド処理開始
            Console.ReadKey();
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
