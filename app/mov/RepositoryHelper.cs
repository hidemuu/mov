using Mov.Configurator.Models;
using Mov.Configurator.Repository;
using Mov.Designer.Models;
using Mov.Designer.Repository.Xml;
using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mov
{
    internal class RepositoryHelper
    {
        #region プロパティ

        internal DesignerDatabase Designer { get; }
        internal ConfiguratorDatabase Configurator { get; }

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
            this.Designer = new DesignerDatabase(resourcePath, "xml");
            this.Configurator = new ConfiguratorDatabase(resourcePath, "json");
        }

        #region メソッド

        internal void WriteAll()
        {
            Console.WriteLine(Designer.LayoutNodes.ToString());
            Console.WriteLine(Designer.Shells.ToString());
            Console.WriteLine(Designer.Contents.ToString());
            Console.WriteLine(Configurator.Configs.ToString());
        }

        #endregion メソッド

    }
}
