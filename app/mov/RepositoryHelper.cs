using Mov.Accessors;
using Mov.Accessors.Repository;
using Mov.Accessors.Repository.Implement;
using Mov.Configurator.Models;
using Mov.Configurator.Repository;
using Mov.Designer.Models;
using Mov.Designer.Repository;
using Mov.UseCases.Creators;
using Mov.UseCases.Factories;
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

        internal IDomainRepositoryCollection<IConfiguratorRepository> Configurator { get; }

        #endregion プロパティ

        /// <summary>
        /// コンストラクター
        /// </summary>
        internal RepositoryHelper()
        {
            var factory = new FileDomainRepositoryFactory(PathCreator.GetResourcePath());
            this.Configurator = factory.Create<IConfiguratorRepository>(SerializeConstants.PATH_JSON);
        }

        #region メソッド

        internal void WriteAll()
        {
            Console.WriteLine(Configurator.Repositories[""].Configs.ToString());
        }

        #endregion メソッド

    }
}
