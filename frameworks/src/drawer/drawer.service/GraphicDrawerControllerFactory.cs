using Mov.Core.Templates.Controllers;
using Mov.Drawer.Models;
using System;
using System.Diagnostics;

namespace Mov.Drawer.Service
{
    public class GraphicDrawerControllerFactory
    {
        #region 定数

        private const string BASE_TYPE_NAME = "Service";

        #endregion 定数

        #region フィールド

        private readonly string baseName;

        private readonly IDrawerRepository repository;

        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        public GraphicDrawerControllerFactory(IDrawerRepository repository)
        {
            this.baseName = this.GetType().Namespace;
            this.repository = repository;
        }

        #region メソッド

        public IGraphicController Create(string code)
        {
            Type type = Type.GetType(baseName + "." + code + BASE_TYPE_NAME);
            if (type == null)
            {
                Debug.Assert(false, type.FullName);
                return null;
            };
            return (IGraphicController)Activator.CreateInstance(type, this.repository);
        }

        #endregion メソッド
    }
}