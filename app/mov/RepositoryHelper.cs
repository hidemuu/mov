using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Implement;
using Mov.Configurator.Models;
using Mov.Configurator.Repository;
using Mov.Designer.Models;
using Mov.Designer.Repository;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mov.ConsoleApp
{
    internal class RepositoryHelper
    {
        #region プロパティ

        internal FileDesignerRepository Designer { get; }
        internal IDomainRepositoryCollection<IConfiguratorRepository> Configurator { get; }

        #endregion プロパティ

        /// <summary>
        /// コンストラクター
        /// </summary>
        internal RepositoryHelper()
        {
            var assembly = Assembly.GetEntryAssembly();
            //var rootPath = assembly.Location.TrimEnd(assembly.ManifestModule.Name.ToCharArray());
            var rootPath = PathHelper.GetCurrentRootPath("mov");
            var resourcePath = Path.Combine(rootPath, "resources");
            this.Designer = new FileDesignerRepository(resourcePath, "xml");
            this.Configurator = new FileDomainRepositoryCollection<IConfiguratorRepository, FileConfiguratorRepository>(resourcePath, "json");
        }

        #region メソッド

        internal void WriteAll()
        {
            Console.WriteLine(Designer.Nodes.ToString());
            Console.WriteLine(Designer.Shells.ToString());
            Console.WriteLine(Designer.Contents.ToString());
            Console.WriteLine(Configurator.Repositories[""].UserSettings.ToString());
        }

        #endregion メソッド

    }
}
