using System;

namespace Mov.Core.Authorizers.Models.Entities
{
    public class BronzeRewardCard : IRewardCard
    {
        private const int TRANSACTION_COST_PER_POINT = 20;

        public int Point { get; private set; }

        public void CalculatePoints(decimal transactionAmount, decimal accountBalance)
        {
            Point += Math.Max((int)decimal.Floor(transactionAmount / TRANSACTION_COST_PER_POINT), 0);
        }
    }
}
