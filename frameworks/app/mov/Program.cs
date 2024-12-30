using Mov.Analizer.Service;
using Mov.Core.Accessors.Models;
using Mov.Core.Configurators.Contexts;
using Mov.Core.Loggers.Attributes;
using Mov.Framework;
using Mov.Framework.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mov.ConsoleApp
{
    internal class Program
    {
        #region field

        private static bool running = true;

        private static IConsoleAppController controller;

        private static IDictionary<string, CommandHandler> handlers;

        private delegate void CommandHandler(IEnumerable<string> parameters);

        #endregion field

        #region main method

        private static void Main(string[] args)
        {
            var mutex = new Mutex(false, FrameworkConstants.APP_NAME + "_ConsoleApp");
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

        #endregion main method

        #region private method

        [LogExecutionTime]
        private static void Initialize()
        {
            //共通コマンド生成
            handlers = new Dictionary<string, CommandHandler>()
            {
                {"execute", Execute },
                {"server", RunServer },
                {"end", EndProgram },
                {"help", Help }
            };


        }

        private static void Run()
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
                        if (handlers.ContainsKey(input))
                        {
                            handlers[input].Invoke(new string[] { });
                            continue;
                        }
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

        private static bool TryGetCommandParameter(string input, out string command, out string[] parameters)
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

        #endregion private method

        #region command handler

        private static void Execute(IEnumerable<string> parameters)
        {
            //var tableLines = Task.WhenAll(_regionAnalizerClient.GetTableLineAsync()).Result[0];
            //var timeTrends = Task.WhenAll(_regionAnalizerClient.GetTrendLineAsync(new RegionRequest(new Dictionary<int, List<int>>() { { 11362, new List<int>() {11 } } }, "population", "all").CreateSchema(), TimeValue.Empty, TimeValue.Empty)).Result[0];
        }

        private static void RunServer(IEnumerable<string> parameters)
        {
            var userSettings = ConfiguratorContext.Current.Service.UserSettingQuery.Reader.ReadAll().ToArray();
            var userSetting = userSettings.FirstOrDefault(x => x.Code.Value.Equals("react_exe"));
            var exePath = new PathValue(Path.Combine(PathCreator.GetSolutionPath(), userSetting.Value));
            //起動したい外部アプリの情報を設定
            var startExeInfo = new System.Diagnostics.ProcessStartInfo(exePath.FileName + exePath.Extension);
            startExeInfo.UseShellExecute = true;
            startExeInfo.WorkingDirectory = exePath.DirPath;
            System.Diagnostics.Process.Start(startExeInfo);

            Thread.Sleep(1000);

            var startInfo = new System.Diagnostics.ProcessStartInfo("http://localhost:5000");
            startInfo.UseShellExecute = true;
            System.Diagnostics.Process.Start(startInfo);
        }

        private static void EndProgram(IEnumerable<string> parameters)
        {
            running = false;
        }

        private static void Help(IEnumerable<string> parameters)
        {
            Console.WriteLine("----- コマンドリスト ------");
            foreach (var key in handlers.Keys)
            {
                Console.WriteLine(key);
            }
            Console.WriteLine(controller.GetDomainCommandHelp());
            Console.WriteLine("----- end ------");
        }

        #endregion command handler
    }
}