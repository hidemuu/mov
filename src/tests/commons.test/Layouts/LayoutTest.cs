using Moq;
using Mov.Authorizers.Accounts;
using Mov.Authorizers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Commons.Test.Layouts
{
    public class LayoutTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Adding100TransactionChangesBalance()
        {
            //Arrange
            var rewardCard = new BronzeRewardCard();
            var account = new Account(rewardCard);

            //Act
            account.AddTransaction(100m);

            //Assert
            Assert.AreEqual(100m, account.Balance);
        }

    }
}
