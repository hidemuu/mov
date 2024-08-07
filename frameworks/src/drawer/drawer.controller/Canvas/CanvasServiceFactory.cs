﻿using Mov.Drawer.Models;
using System;
using System.Diagnostics;

namespace Mov.Drawer.Controller.Canvas
{
    public class CanvasServiceFactory
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
        public CanvasServiceFactory(IDrawerRepository repository)
        {
            baseName = GetType().Namespace;
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
            return (CanvasServiceBase)Activator.CreateInstance(type, repository);
        }

        #endregion メソッド
    }
}