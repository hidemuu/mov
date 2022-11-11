using Mov.Accessors;
using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository.Persistences.Entity
{
    public class LandmarkCommand : IPersistenceCommand<Landmark>
    {
        #region フィールド

        private readonly IGameRepository repository;

        #endregion フィールド

        #region コンストラクター

        public LandmarkCommand(IGameRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Write()
        {
            this.repository.Landmarks.Write();
        }

        public void Delete(Landmark item)
        {
            this.repository.Landmarks.Delete(item);
        }

        public void Post(Landmark item)
        {
            this.repository.Landmarks.Post(item);
        }

        #endregion メソッド
    }
}
