using Mov.Game.Models.Characters;
using Mov.Game.Repository;
using Mov.Game.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Game.ViewModels.Services
{
    public class GameService : GameServiceBase
    {

        public GameService(LandmarkRepository landMarkRepository) : base(landMarkRepository)
        {
        }

        protected override void ClearScreen()
        {
            ScreenGraphics.Clear(Color.White);
        }

        protected override void DisposeScreen()
        {
            ScreenGraphics.Dispose();
        }

        protected override void DrawCharacter(CharacterBase character)
        {
            character.Draw(ScreenGraphics);
        }

        protected override void InvalidateScreen()
        {
            //throw new NotImplementedException();
        }
    }
}
