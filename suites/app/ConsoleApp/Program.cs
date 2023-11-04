using Mov.Analizer.Models;
using Mov.Analizer.Repository;
using Mov.Analizer.Service;
using Mov.Analizer.Service.Regions;
using Mov.Analizer.Service.Regions.Entities;
using Mov.Core.Configurators.Contexts;
using Mov.Core.Configurators.Models.Entities;
using Mov.Core.Valuables;
using Mov.Framework.Services;
using Mov.Suite.AnalizerClient.Resas;
using Mov.Suite.AnalizerClient.Resas.Controllers;
using Mov.Suite.AnalizerClient.Resas.Repository;

internal class Program
{
    #region field

    private static bool _running = true;

    private static ResasCommandController _resasController;

    private static IRegionAnalizerClient? _regionAnalizerClient;

	private static IDictionary<string, Func<string[], string>> _handlers;

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
		var resourcePath = PathCreator.GetResourcePath();
		var analizerRepository = new FileAnalizerRepository(resourcePath);

		ConfiguratorContext.Initialize(PathCreator.GetResourcePath());
        var apis = ConfiguratorContext.Current.Service.ApiSettingQuery.Reader.ReadAll().ToArray();
        var apiSetting = apis.FirstOrDefault(x => x.Code.Value.Equals("RESAS-API-KEY")) ?? ApiSetting.Empty;
		var resasRepository = new RestResasRepository(apiSetting.Value);
        _regionAnalizerClient = new ResasAnalizerClient(analizerRepository, resasRepository);
        _resasController = new ResasCommandController(resasRepository);
		_handlers = new Dictionary<string, Func<string[], string>>()
	    {
			{"execute", Execute },
			{"end", EndProgram },
		    {"help", Help }
	    };
        foreach(var command in _resasController.CreateCommandHandlers())
        {
            _handlers.Add(command.Key, command.Value);
        }
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

    private static string Execute(IEnumerable<string> parameters)
    {
        var tableLines = Task.WhenAll(_regionAnalizerClient.GetTableLineAsync()).Result[0];
        var timeTrends = Task.WhenAll(_regionAnalizerClient.GetTrendLineAsync(new RegionRequest(11362, 11, "population", "all").CreateSchema(), TimeValue.Empty, TimeValue.Empty)).Result[0];
        return string.Empty;
    }

    private static string EndProgram(IEnumerable<string> parameters)
    {
        _running = false;
        return string.Empty;
    }

    private static string Help(IEnumerable<string> parameters)
    {
        Console.WriteLine("----- コマンドリスト ------");
        foreach (var key in _handlers.Keys)
        {
            Console.WriteLine(key);
        }
		Console.WriteLine("----- コマンド説明 ------");
		foreach (var help in _resasController.GetCommandHelps())
        {
            Console.WriteLine($"{help.Item1} : {help.Item2}");
        }
        Console.WriteLine("----- end ------");
        return string.Empty;
    }

    #endregion command handler
}