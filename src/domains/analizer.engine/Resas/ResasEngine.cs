using Mov.Analizer.Models;
using Mov.Analizer.Models.Apis.Resas;
using System;

namespace Mov.Analizer.Engine
{
    public class ResasEngine : IResasEngine
    {
        #region フィールド

        private readonly IResasContext parameter;

        #endregion フィールド

        public ResasEngine(IResasContext parameter)
        {
            this.parameter = parameter;
        }
    }
}
