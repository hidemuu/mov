using Mov.Configurator.Repository;
using Mov.Designer.Repository.Xml;
using Mov.Utilities;
using System;
using System.IO;

namespace Mov
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Mov!");
            var rootPath = PathHelper.GetCurrentRootPath("mov");
            var assetPath = Path.Combine(rootPath, "assets");
            var designerRepository = new DesignerRepositoryCollection(Path.Combine(assetPath, "designer"), "xml");
            Console.WriteLine("Designer - PartsLayouts");
            Console.WriteLine(designerRepository.PartsLayouts.ToString());
            Console.WriteLine("Designer - ShellLayouts");
            Console.WriteLine(designerRepository.ShellLayouts.ToString());

            var configuratorRepository = new ConfiguratorRepositoryCollection(Path.Combine(assetPath, "configurator"), "json");
            Console.WriteLine("Configurator - UserSettings");
            Console.WriteLine(configuratorRepository.UserSettings.ToString());

            Console.ReadKey();
        }
    }
}
