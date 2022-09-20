using Mov.Accessors;
using Mov.Accessors.Repository;
using Mov.Configurator.Models;
using Mov.Configurator.Repository;
using Mov.Designer.Repository;
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
        static IDomainRepositoryCollection<IConfiguratorRepository> configurator;

        private delegate void CommandHandler(IEnumerable<string> parameters);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Mov!");
            //リポジトリ生成
            var repositoryFactory = new FileDomainRepositoryFactory(PathCreator.GetResourcePath());
            configurator = repositoryFactory.Create<IConfiguratorRepository>(SerializeConstants.PATH_JSON);
            Console.WriteLine(configurator.Repositories[""].Configs.ToString());

            //コマンド処理開始
            Console.ReadKey();
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine() ?? string.Empty;
                var tokens = input.Split(' ');

                if(tokens.Length < 1)
                {
                    Console.WriteLine("コマンドを入力してください");
                    continue;
                }

                var command = tokens.First();
                var parameters = tokens.Skip(1);

                var handlers = new Dictionary<string, CommandHandler>();

                if (!handlers.ContainsKey(command))
                {
                    Console.WriteLine($"コマンドが登録されていません : {command}");
                }
                else
                {
                    handlers[command].Invoke(parameters);
                }
            }

        }
    }
}
