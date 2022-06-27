using Mov.Authorizer.Repository;
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

        internal DesignerRepositoryCollection Designer { get; }
        internal ConfiguratorRepositoryCollection Configurator { get; }
        internal AuthorizerRepositoryCollection Authorizer { get; }

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
            this.Designer = new DesignerRepositoryCollection(resourcePath, "xml");
            this.Configurator = new ConfiguratorRepositoryCollection(resourcePath, "json");
            this.Authorizer = new AuthorizerRepositoryCollection(resourcePath, "json");
        }

        #region メソッド

        internal void WriteAll()
        {
            Console.WriteLine(Designer.LayoutTrees.ToString());
            Console.WriteLine(Designer.ShellLayouts.ToString());
            Console.WriteLine(Designer.ContentTables.ToString());
            Console.WriteLine(Configurator.UserSettings.ToString());
            Console.WriteLine(Configurator.Variables.ToString());
            Console.WriteLine(Authorizer.Users.ToString());
        }

        #endregion メソッド

    }
}
