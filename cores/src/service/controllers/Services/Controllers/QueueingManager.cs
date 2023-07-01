using System.Collections.Generic;

namespace Mov.Core.Controllers.Services.Controllers
{
    /// <summary>
    /// 上位アプリケーションからの指令を格納
    /// </summary>
    public class QueueingManager<TQueue>
    {
        #region プロパティ

        public IEnumerable<TQueue> Queues { get; set; }

        #endregion プロパティ

        #region コンストラクター

        public QueueingManager()
        {
            Queues = new List<TQueue>();
        }

        #endregion コンストラクター

    }
}
