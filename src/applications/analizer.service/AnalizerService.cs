using Mov.Analizer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service
{
    public class AnalizerService : IAnalizerService
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public AnalizerService(IAnalizerRepository repository)
        {
        }
    }
}
