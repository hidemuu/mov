using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Services.Controllers
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
