using Mov.Accessors;
using Mov.Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Game.Repository.Persistences.Entity
{
    public class LandmarkQuery : IPersistenceQuery<Landmark>
    {
        #region フィールド

        private readonly IGameRepository repository;

        #endregion フィールド

        #region コンストラクター

        public LandmarkQuery(IGameRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<Landmark> Get()
        {
            return this.repository.Landmarks.Get();
        }

        public IEnumerable<Landmark> Get(string param)
        {
            return Get().Where(x => x.Code == param);
        }

        public Landmark Get(Guid id)
        {
            return this.repository.Landmarks.Get(id);
        }

        public override string ToString() => this.repository.Landmarks.ToString();

        #endregion メソッド
    }
}
