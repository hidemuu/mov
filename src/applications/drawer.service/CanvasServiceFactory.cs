using Mov.Drawer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mov.Drawer.Service
{
    public class CanvasServiceFactory
    {
        #region 定数

        private const string BASE_TYPE_NAME = "Service";

        #endregion 定数

        #region フィールド

        private readonly string baseName;

        private readonly IDrawerDatabase repository;

        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        public CanvasServiceFactory(IDrawerDatabase repository)
        {
            this.baseName = this.GetType().Namespace;
            this.repository = repository;
        }

        #region メソッド

        public CanvasServiceBase Create(string code)
        {
            
            Type type = Type.GetType(baseName + "." + code + BASE_TYPE_NAME);
            if (type == null)
            {
                Debug.Assert(false, type.FullName);
                return null;
            };
            return (CanvasServiceBase)Activator.CreateInstance(type, this.repository);
        }

        #endregion メソッド
    }
}
