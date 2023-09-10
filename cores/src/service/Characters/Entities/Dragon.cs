using System;

namespace Mov.Core.Characters.Entities
{
    internal class Dragon : IBird, ILizard
    {
        private IBird bird;
        private ILizard lizard;

        public Dragon(IBird bird, ILizard lizard)
        {
            this.bird = bird ?? throw new ArgumentNullException(paramName: nameof(bird));
            this.lizard = lizard ?? throw new ArgumentNullException(paramName: nameof(lizard));
        }

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }
    }
}
