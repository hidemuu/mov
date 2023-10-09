using Mov.Framework;
using Mov.Framework.Engines;
using Mov.Suite.Controllers;
using Mov.Suite.Facades;

internal class Program
{
    #region field

    private static bool _running = true;

    private static IConsoleAppController _controller;

    private static IDictionary<string, CommandHandler> _handlers = new Dictionary<string, CommandHandler>()
            {
                {"end", EndProgram },
                {"help", Help }
            };

    private delegate void CommandHandler(IEnumerable<string> parameters);

    #endregion field

    #region main method

    private static void Main(string[] args)
    {
        var mutex = new Mutex(false, "Mov_Suite_ConsoleApp");
        //二重起動防止
        if (!mutex.WaitOne(0, false))
        {
            Console.WriteLine("二重起動できません。");
            mutex.Close();
            mutex = null;
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Hello Mov Suite!");

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

    private static void Initialize()
    {
        //エンジン生成
        var engine = new MovEngine(0, new EmptyMovFacade());
        _controller = new ConsoleAppController(engine);
    }

    private static void Run()
    {
        while (_running)
        {
            //コントローラー生成
            while (_running)
            {
                Console.WriteLine("ドメインを入力してください");
                Console.WriteLine("--------------");
                Console.WriteLine(_controller.GetDomainHelp());
                Console.WriteLine("--------------");
                Console.Write("> ");
                var input = Console.ReadLine() ?? string.Empty;
                if (!_controller.SetDomain(input))
                {
                    Console.WriteLine("コントローラーの生成に失敗しました");
                    if (_handlers.ContainsKey(input))
                    {
                        _handlers[input].Invoke(new string[] { });
                        continue;
                    }
                    continue;
                }
                Console.WriteLine("コントローラーを生成しました");
                Help(new string[] { });
                break;
            }

            //コマンド処理
            while (_running)
            {
                Console.Write("> ");
                var input = Console.ReadLine() ?? string.Empty;
                if (!TryGetCommandParameter(input, out string command, out string[] parameters))
                {
                    Console.WriteLine("コマンドを入力してください");
                    continue;
                }
                if (_handlers.ContainsKey(command))
                {
                    _handlers[command].Invoke(parameters);
                    continue;
                }
                if (!_controller.ExistsDomainCommand(command))
                {
                    Console.WriteLine($"コマンドが登録されていません : {command}");
                }
                else
                {
                    _controller.ExecuteDomainCommand(command, parameters);
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

    private static void EndProgram(IEnumerable<string> parameters)
    {
        _running = false;
    }

    private static void Help(IEnumerable<string> parameters)
    {
        Console.WriteLine("----- コマンドリスト ------");
        foreach (var key in _handlers.Keys)
        {
            Console.WriteLine(key);
        }
        Console.WriteLine(_controller.GetDomainCommandHelp());
        Console.WriteLine("----- end ------");
    }

    #endregion command handler
}