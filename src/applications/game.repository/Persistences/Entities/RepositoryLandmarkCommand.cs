using Mov.Accessors;
using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Repository.Persistences.Entity
{
    public class RepositoryLandmarkCommand : IPersistenceCommand<Landmark>
    {
        #region フィールド

        private readonly IGameRepository repository;

        #endregion フィールド

        #region コンストラクター

        public RepositoryLandmarkCommand(IGameRepository repository)
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
        public void Posts(IEnumerable<Landmark> items)
        {
            this.repository.Landmarks.Posts(items);
        }
        public void Post(Landmark item)
        {
            this.repository.Landmarks.Post(item);
        }
        public void Put(Landmark item)
        {
            this.repository.Landmarks.Put(item);
        }

        #endregion メソッド
    }
}
