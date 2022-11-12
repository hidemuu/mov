using Mov.Analizer.Models;
using Mov.Analizer.Models.Parameters;
using System;

namespace Mov.Analizer.Engine
{
    public class AnalizerEngine : IAnalizerEngine
    {
        #region フィールド

        private readonly IAnalizerParameter parameter;

        #endregion フィールド

        public AnalizerEngine(IAnalizerParameter parameter)
        {
            this.parameter = parameter;
        }
    }
}
