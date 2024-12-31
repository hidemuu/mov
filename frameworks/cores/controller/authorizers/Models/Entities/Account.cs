namespace Mov.Core.Authorizers.Models.Entities
{
    public class Account
    {
        #region field

        private readonly IRewardCard rewardCard;

        #endregion field

        #region property

        public decimal Balance { get; private set; }

        #endregion propety

        #region constructor

        public Account(IRewardCard rewardCard)
        {
            this.rewardCard = rewardCard;
        }

        #endregion constructor

        #region method

        public void AddTransaction(decimal amount)
        {
            rewardCard.CalculatePoints(amount, Balance);
            Balance += amount;
        }

        #endregion method
    }
}
