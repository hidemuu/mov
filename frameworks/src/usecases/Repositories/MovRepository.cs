using Mov.Analizer.Models;
using Mov.Designer.Models;
using Mov.Framework;
using Mov.Game.Models;

namespace Mov.UseCases.Repositories
{
    public class MovRepository : IMovRepository
    {
        public IAnalizerRepository Analizer { get; }
        public IDesignerRepository Designer { get; }
        public IGameRepository Game { get; }

        public MovRepository(IAnalizerRepository analizer,
            IDesignerRepository designer,
            IGameRepository game)
        {
            this.Analizer = analizer;
            this.Designer = designer;
            this.Game = game;
        }
    }
}