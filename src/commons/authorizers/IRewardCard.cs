using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Authorizers
{
    public interface IRewardCard
    {
        int Point { get; }

        void CalculatePoints(decimal transactionAmount, decimal accountBalance);
    }
}
