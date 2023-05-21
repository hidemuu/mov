using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Authorizers.Models.Entities
{
    public class Account
    {
        private readonly IRewardCard rewardCard;

        public decimal Balance { get; private set; }

        public Account(IRewardCard rewardCard)
        {
            this.rewardCard = rewardCard;
        }

        public void AddTransaction(decimal amount)
        {
            rewardCard.CalculatePoints(amount, Balance);
            Balance += amount;
        }
    }
}
