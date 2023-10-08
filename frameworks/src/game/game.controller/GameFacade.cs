using Mov.Game.Models;
using Mov.Game.Models.Schemas;
using Mov.Game.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Controller
{
    internal class GameFacade : IGameFacade
    {


        #region method

        public IGraphicGame CreateGraphicGame()
        {
            throw new NotImplementedException();
        }

        public LandmarkSchema GetLandmark()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetLevels()
        {
            throw new NotImplementedException();
        }

        public int GetPlayerLife()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}
