using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Authorizers.Models.Entities
{
    public class PlatinumRewardCard : IRewardCard
    {
        private const int TRANSACTION_COST_PER_POINT = 2;

        private const int BALANCE_COST_PER_POINT = 1000;
        public int Point { get; private set; }

        public void CalculatePoints(decimal transactionAmount, decimal accountBalance)
        {
            Point += Math.Max((int)decimal.Ceiling(
                accountBalance / BALANCE_COST_PER_POINT +
                transactionAmount / TRANSACTION_COST_PER_POINT), 0);
        }
    }
}
