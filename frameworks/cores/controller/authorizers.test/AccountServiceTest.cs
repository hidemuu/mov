using Mov.Core.Authorizers.Models.Entities;
using Mov.Core.Authorizers.Services;
using Mov.Core.Authorizers.Test.Builders;
using NUnit.Framework;

namespace Mov.Core.Authorizers.Test
{
    public class AccountServiceTest
    {
        #region field

        private AccountRepositoryBuilder _accountRepositoryBuilder;

        #endregion field

        #region setup

        [SetUp]
        public void Setup()
        {
            _accountRepositoryBuilder = new AccountRepositoryBuilder();
        }

        #endregion setup

        #region test

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
            var repository = _accountRepositoryBuilder
                .WithGetByNameCalled("Trading Account", account)
                .Build();
            var sut = new AccountService(repository);

            //Act
            sut.AddTransactionToAccount("Trading Account", 200m);

            //Assert
            Assert.AreEqual(200m, account.Balance);
        }

        #endregion test
    }
}