using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Utilities.Templates.Strategies
{
    public class StrategyContext
    {
        #region フィールド

        private readonly IList<IStrategy> _strategies;
        private IStrategy _currentStrategy;
        private string _prevStrategyCode;
        private string _nextStrategyCode;

        #endregion フィールド

        #region コンストラクター

        public StrategyContext(IList<IStrategy> strategies)
        {
            _strategies = strategies;
            _currentStrategy = _strategies[0];
            _nextStrategyCode = _currentStrategy.GetNextCode();
        }

        #endregion コンストラクター

        #region メソッド

        public void Run()
        {
            //シーケンス更新
            if (!_currentStrategy.Execute()) return;
            _prevStrategyCode = _currentStrategy.GetCode();
            _currentStrategy = _strategies.FirstOrDefault(x => x.GetCode() == _currentStrategy.GetNextCode());
            _nextStrategyCode = _currentStrategy.GetNextCode();
        }

        public string GetCurrentStrategyCode()
        {
            return _currentStrategy.GetCode();
        }
        public string GetPrevStrategyCode()
        {
            return _prevStrategyCode;
        }
        public string GetNextStrategyCode()
        {
            return _nextStrategyCode;
        }

        #endregion メソッド
    }
}
