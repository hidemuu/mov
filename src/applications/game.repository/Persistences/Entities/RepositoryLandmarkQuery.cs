using Mov.Accessors;
using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Game.Repository.Persistences.Entity
{
    public class RepositoryLandmarkQuery : IPersistenceQuery<Landmark>
    {
        #region フィールド

        private readonly IGameRepository repository;

        #endregion フィールド

        #region コンストラクター

        public RepositoryLandmarkQuery(IGameRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<Landmark> Read()
        {
            return this.repository.Landmarks.Read().Items;
        }

        public IEnumerable<Landmark> Gets()
        {
            return this.repository.Landmarks.Get();
        }

        public IEnumerable<Landmark> Gets(string param)
        {
            return Gets().Where(x => x.Code == param);
        }

        public Landmark Get(Guid id)
        {
            return this.repository.Landmarks.Get(id);
        }

        public Landmark Get(string param)
        {
            return this.repository.Landmarks.Get(param);
        }

        public override string ToString() => this.repository.Landmarks.ToString();

        #endregion メソッド
    }
}
