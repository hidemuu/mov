using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Loggers
{
    public class ClassLogger
    {
        #region フィールド

        private Logger logger;

        #endregion フィールド

        #region コンストラクター

        public ClassLogger()
        {
            this.logger = LogManager.GetCurrentClassLogger();
        }

        #endregion コンストラクター

        #region メソッド

        public void Error(Exception ex, string message)
        {
            logger.Error(ex, message);
        }

        #endregion メソッド
    }
}
