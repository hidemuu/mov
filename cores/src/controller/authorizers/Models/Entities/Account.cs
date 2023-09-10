namespace Mov.Core.Authorizers.Models.Entities
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
