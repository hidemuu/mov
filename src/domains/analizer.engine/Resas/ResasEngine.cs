using Mov.Analizer.Models;
using Mov.Analizer.Models.Parameters;
using System;

namespace Mov.Analizer.Engine
{
    public class ResasEngine : IResasEngine
    {
        #region フィールド

        private readonly IResasParameter parameter;

        #endregion フィールド

        public ResasEngine(IResasParameter parameter)
        {
            this.parameter = parameter;
        }
    }
}
