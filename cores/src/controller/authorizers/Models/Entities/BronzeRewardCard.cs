using System;

namespace Mov.Core.Authorizers.Models.Entities
{
    public class BronzeRewardCard : IRewardCard
    {
        #region constant

        private const int TRANSACTION_COST_PER_POINT = 20;

        #endregion constant

        #region property

        public int Point { get; private set; }

        #endregion property

        #region method

        public void CalculatePoints(decimal transactionAmount, decimal accountBalance)
        {
            Point += Math.Max((int)decimal.Floor(transactionAmount / TRANSACTION_COST_PER_POINT), 0);
        }

        #endregion method
    }
}
