using Mov.Suite.AnalizerClient.Resas.Repository;

internal class Program
{
    #region field

    private static bool _running = true;

    private static IDictionary<string, CommandHandler> _handlers = new Dictionary<string, CommandHandler>()
    {
        {"resascity", GetRestResasCities },
        {"resaspref", GetRestResasPrefectures },
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
    }

    private static void Run()
    {
        while (_running)
        {
            //コントローラー生成
            while (_running)
            {
                Console.Write("> ");
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

    private static void GetRestResasCities(IEnumerable<string> parameters)
    {
        var parameterArray = parameters.ToArray();
        var resasRepository = new RestResasRepository(parameterArray[0], parameterArray[1]);
        var cities = Task.WhenAll(resasRepository.Cities.GetAsync()).Result[0].ToArray();
        foreach (var city in cities)
        {
            Console.WriteLine(city.Id);
            foreach (var result in city.Results)
            {
                Console.WriteLine(result);
            }
        }
    }

    private static void GetRestResasPrefectures(IEnumerable<string> parameters)
    {
        var parameterArray = parameters.ToArray();
        var resasRepository = new RestResasRepository(parameterArray[0], parameterArray[1]);
        var prefectures = Task.WhenAll(resasRepository.Prefectures.GetAsync()).Result[0].ToArray();
        foreach (var prefecture in prefectures)
        {
            Console.WriteLine(prefecture.Id);
            foreach (var result in prefecture.Results)
            {
                Console.WriteLine(result);
            }
        }
    }

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
        Console.WriteLine("----- end ------");
    }

    #endregion command handler
}