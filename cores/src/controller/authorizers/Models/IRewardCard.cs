namespace Mov.Core.Authorizers.Models
{
    public interface IRewardCard
    {
        #region proeprty

        int Point { get; }

        #endregion property

        #region method

        void CalculatePoints(decimal transactionAmount, decimal accountBalance);

        #endregion method
    }
}
