using Mov.Analizer.Models;
using Mov.Controllers.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service
{
    public class AnalizerService : RepositoryCommandService<IAnalizerRepository>
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public AnalizerService(IAnalizerRepository repository) : base(repository, new AnalizerCommandFactory())
        {
        }
    }
}
