using Mov.Configurator.Repository;
using Mov.Designer.Repository;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mov
{
    class Program
    {
        private delegate void CommandHandler(IEnumerable<string> parameters);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Mov!");
            RepositoryHelper repositoryHelper = new RepositoryHelper();
            repositoryHelper.WriteAll();
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
