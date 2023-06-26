using System;
using System.Collections.Generic;
using System.Text;
using Mov.Analizer.Models;
using Mov.Designer.Models;
using Mov.Driver.Models;
using Mov.Framework;
using Mov.Game.Models;

namespace Mov.UseCases.Repositories
{
    public class MovRepository : IMovRepository
    {
        public IAnalizerRepository Analizer { get; }
        public IDesignerRepository Designer { get; }
        public IDriverRepository Driver { get; }
        public IGameRepository Game { get; }

        public MovRepository(IAnalizerRepository analizer,
            IDesignerRepository designer, IDriverRepository driver,
            IGameRepository game)
        {
            this.Analizer = analizer;
            this.Designer = designer;
            this.Driver = driver;
            this.Game = game;
        }

    }
}
