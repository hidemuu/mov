using Mov.Game.Models.Schemas;
using Mov.Game.Service;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Mov.Game.Controller
{
    public class SimpleGraphicGameFacade : IGameFacade
    {
        #region field

        private readonly IGraphicGame _game;

        #endregion field

        #region constructor

        public SimpleGraphicGameFacade(IGraphicGame graphicGame) 
        {
            _game= graphicGame;
        }

        #endregion constructor

        #region method

        public IGraphicGame CreateGraphicGame()
        {
            return _game;
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
