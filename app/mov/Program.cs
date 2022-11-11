using Mov.Accessors;
using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Domain;
using Mov.Analizer.Models;
using Mov.Analizer.Service;
using Mov.Configurator.Models;
using Mov.Configurator.Repository;
using Mov.Configurator.Service;
using Mov.Controllers;
using Mov.Designer.Models;
using Mov.Designer.Repository;
using Mov.Designer.Service;
using Mov.Driver.Models;
using Mov.Driver.Service;
using Mov.Framework;
using Mov.Framework.Controllers;
using Mov.Game.Models;
using Mov.Game.Service;
using Mov.Game.Service.Puzzle;
using Mov.UseCases;
using Mov.UseCases.Controllers;
using Mov.UseCases.Factories;
using Mov.UseCases.Repositories;
using Mov.UseCases.Services;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Mov.ConsoleApp
{
    class Program
    {

        #region フィールド

        static Mutex mutex = new Mutex(false, FrameworkConstants.APP_NAME + "_ConsoleApp");

        static bool running = true;

        static IMovRepository repository;
        static IMovEngine engine;
        static IMovController controller;

        static IDictionary<string, CommandHandler> handlers;

        delegate void CommandHandler(IEnumerable<string> parameters);

        #endregion フィールド

        static void Main(string[] args)
        {
            //二重起動防止
            if (!mutex.WaitOne(0, false))
            {
                Console.WriteLine("二重起動できません。");
                mutex.Close();
                mutex = null;
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Hello Mov!");

            //初期化
            Initialize();

            //実行
            Run();

            //終了処理
            Console.WriteLine("アプリケーションを終了します");
            Console.ReadKey();

            if (mutex != null)
            {
                mutex.ReleaseMutex();
                mutex.Close();
            }

        }

        #region メソッド

        static void Initialize()
        {
            //共通コマンド生成
            handlers = new Dictionary<string, CommandHandler>()
            {
                {"end", EndProgram },
                {"help", Help }
            };
            //リポジトリ生成
            repository = new FileMovRepository(PathCreator.GetResourcePath());
            //エンジン生成
            //engine = new MovEngine(0, new MovService(
            //    new AnalizerService(repository.Analizer),
            //    new ConfiguratorService(repository.Configurator),
            //    new DesignerService(repository.Designer),
            //    new DriverService(repository.Driver),
            //    new GameService(repository.Game),
            //    new TranslatorService(repository.Translator)
            //    ));
            controller = new MovController(engine);
        }

        static void Run()
        {
           
            while (running)
            {
                //コントローラー生成
                while (running)
                {
                    Console.WriteLine("ドメインを入力してください");
                    Console.WriteLine("--------------");
                    Console.WriteLine(controller.GetDomainHelp());
                    Console.WriteLine("--------------");
                    Console.Write("> ");
                    var input = Console.ReadLine() ?? string.Empty;
                    if (!controller.SetDomain(input))
                    {
                        Console.WriteLine("コントローラーの生成に失敗しました");
                        continue;
                    }
                    Console.WriteLine("コントローラーを生成しました");
                    Help(new string[] { });
                    break;
                }

                //コマンド処理
                while (running)
                {
                    Console.Write("> ");
                    var input = Console.ReadLine() ?? string.Empty;
                    if (!TryGetCommandParameter(input, out string command, out string[] parameters))
                    {
                        Console.WriteLine("コマンドを入力してください");
                        continue;
                    }
                    if (handlers.ContainsKey(command))
                    {
                        handlers[command].Invoke(parameters);
                        continue;
                    }
                    if (!controller.ExistsDomainCommand(command))
                    {
                        Console.WriteLine($"コマンドが登録されていません : {command}");
                    }
                    else
                    {
                        controller.ExecuteDomainCommand(command, parameters);
                    }
                }
            }
        }

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

        #region コマンドハンドラ

        private static void EndProgram(IEnumerable<string> parameters)
        {
            running = false;
        }

        private static void Help(IEnumerable<string> parameters)
        {
            Console.WriteLine("----- コマンドリスト ------");
            foreach(var key in handlers.Keys)
            {
                Console.WriteLine(key);
            }
            Console.WriteLine(controller.GetDomainCommandHelp());
            Console.WriteLine("----- end ------");
        }

        #endregion コマンドハンドラ
    }
}
