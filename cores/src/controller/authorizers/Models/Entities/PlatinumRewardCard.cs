﻿using System;

namespace Mov.Core.Authorizers.Models.Entities
{
    public class PlatinumRewardCard : IRewardCard
    {
        #region constant

        private const int TRANSACTION_COST_PER_POINT = 2;

        private const int BALANCE_COST_PER_POINT = 1000;

        #endregion constant

        #region property

        public int Point { get; private set; }

        #endregion proeprty

        #region method

        public void CalculatePoints(decimal transactionAmount, decimal accountBalance)
        {
            Point += Math.Max((int)decimal.Ceiling(
                accountBalance / BALANCE_COST_PER_POINT +
                transactionAmount / TRANSACTION_COST_PER_POINT), 0);
        }

        #endregion method
    }
}
