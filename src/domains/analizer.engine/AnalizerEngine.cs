using Mov.Analizer.Models;
using System;

namespace Mov.Analizer.Engine
{
    public class AnalizerEngine
    {
        #region フィールド

        private readonly IAnalizerService service;

        #endregion フィールド

        public AnalizerEngine(IAnalizerService service)
        {
            this.service = service;
        }
    }
}
