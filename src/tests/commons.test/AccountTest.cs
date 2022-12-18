using Moq;
using Mov.Authorizers;
using Mov.Authorizers.Accounts;
using NUnit.Framework;

namespace Mov.Commons.Test
{
    public class AccountTest
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

        [Test]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            //Arrange
            var rewardCard = new BronzeRewardCard();
            var account = new Account(rewardCard);
            var repository = new Mock<IAccountRepository>().Object;
            var sut = new AccountService(repository);

            //Act
            sut.AddTransactionToAccount("Trading Account", 200m);

            //Assert
            Assert.AreEqual(200m, account.Balance);
        }
    }
}