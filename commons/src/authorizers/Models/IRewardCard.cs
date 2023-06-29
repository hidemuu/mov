namespace Mov.Core.Authorizers.Models
{
    public interface IRewardCard
    {
        int Point { get; }

        void CalculatePoints(decimal transactionAmount, decimal accountBalance);
    }
}
