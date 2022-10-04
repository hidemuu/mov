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
using Mov.Game.Models;
using Mov.Game.Service;
using Mov.Translator.Models;
using Mov.Translator.Service;
using Mov.UseCases;
using Mov.UseCases.Factories;
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
        #region 定数

        const string ANALIZE = "analize";
        const string AUTH = "auth";
        const string BOM = "bom";
        const string CONFIG = "config";
        const string DESIGN = "design";
        const string DRAW = "draw";
        const string DRIVER = "driver";
        const string GAME = "game";
        const string SCHEDULE = "schedule";
        const string TRANSLATE = "translate";

        #endregion 定数

        #region フィールド

        static Mutex mutex = new Mutex(false, "Mov_ConsoleApp");

        static bool running = true;

        static IDomainRepositoryCollection<IAnalizerRepository> analizerRepository;
        static IDomainRepositoryCollection<IConfiguratorRepository> configRepository;
        static IDomainRepositoryCollection<IDesignerRepository> designerRepository;
        static IDomainRepositoryCollection<IDriverRepository> driverRepository;
        static IDomainRepositoryCollection<IGameRepository> gameRepository;
        static IDomainRepositoryCollection<ITranslatorRepository> translatorRepository;
        static IController domainController;

        static IDictionary<string, CommandHandler> handlers;

        delegate void CommandHandler(IEnumerable<string> parameters);

        #endregion フィールド

        static void Main(string[] args)
        {
            if (!mutex.WaitOne(0, false))
            {
                Console.WriteLine("二重起動できません。");
                mutex.Close();
                mutex = null;
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Hello Mov!");
            
            Run();

            Console.WriteLine("アプリケーションを終了します");
            Console.ReadKey();

            if (mutex != null)
            {
                mutex.ReleaseMutex();
                mutex.Close();
            }

        }

        #region メソッド

        static void Run()
        {
            //共通コマンド生成
            handlers = new Dictionary<string, CommandHandler>()
            {
                {"end", EndProgram },
                {"help", Help }
            };
            //リポジトリ生成
            CreateRepository(PathCreator.GetResourcePath());

            while (running)
            {
                //コントローラー生成
                while (running)
                {
                    Console.WriteLine("ドメインを入力してください");
                    Console.WriteLine(ANALIZE + " : " + "アナライザー");
                    Console.WriteLine(CONFIG + " : " + "コンフィグ");
                    Console.WriteLine(DESIGN + " : " + "デザイン");
                    Console.WriteLine(DRIVER + " : " + "ドライバー");
                    Console.WriteLine(GAME + " : " + "ゲーム");
                    Console.WriteLine(TRANSLATE + " : " + "翻訳");
                    Console.WriteLine("--------------");
                    Console.Write("> ");
                    var input = Console.ReadLine() ?? string.Empty;
                    if (!CreateDomainController(input))
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

        static void CreateRepository(string resourcePath)
        {
            var fileRepositoryFactory = new FileDomainRepositoryCollectionFactory(resourcePath);
            configRepository = fileRepositoryFactory.Create<IConfiguratorRepository>(SerializeConstants.PATH_JSON);
            designerRepository = fileRepositoryFactory.Create<IDesignerRepository>(SerializeConstants.PATH_XML);
            gameRepository = fileRepositoryFactory.Create<IGameRepository>(SerializeConstants.PATH_JSON);
            driverRepository = fileRepositoryFactory.Create<IDriverRepository>(SerializeConstants.PATH_JSON);
            analizerRepository = fileRepositoryFactory.Create<IAnalizerRepository>(SerializeConstants.PATH_JSON);
            translatorRepository = fileRepositoryFactory.Create<ITranslatorRepository>(SerializeConstants.PATH_JSON);
        }

        static bool CreateDomainController(string domain)
        {
            switch (domain)
            {
                case CONFIG:
                    domainController = new DomainController<IDomainRepository>(
                        configRepository.DefaultRepository,
                        new ConfiguratorService(configRepository.DefaultRepository));
                    break;
                case DESIGN:
                    domainController = new DomainController<IDomainRepository>(
                        designerRepository.DefaultRepository,
                        new DesignerService(designerRepository.DefaultRepository));
                    break;
                case GAME:
                    domainController = new DomainController<IDomainRepository>(
                        gameRepository.DefaultRepository,
                        new GameService(gameRepository.DefaultRepository));
                    break;
                case DRIVER:
                    domainController = new DomainController<IDomainRepository>(
                        driverRepository.DefaultRepository,
                        new DriverService(driverRepository.DefaultRepository));
                    break;
                case ANALIZE:
                    domainController = new DomainController<IDomainRepository>(
                        analizerRepository.DefaultRepository,
                        new AnalizerService(analizerRepository.DefaultRepository));
                    break;
                case TRANSLATE:
                    domainController = new DomainController<IDomainRepository>(
                        translatorRepository.DefaultRepository,
                        new TranslatorService(translatorRepository.DefaultRepository));
                    break;
                default:
                    return false;
            }
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
            Console.WriteLine(domainController.GetCommandHelp());
            Console.WriteLine("----- end ------");
        }

        #endregion コマンドハンドラ
    }
}
