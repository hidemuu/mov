using Mov.Accessors;
using Mov.Configurator.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorService
    {
        #region プロパティ

        IConfiguratorQuery Query { get; }

        IConfiguratorCommand Command { get; }


        #endregion プロパティ
    }
}
