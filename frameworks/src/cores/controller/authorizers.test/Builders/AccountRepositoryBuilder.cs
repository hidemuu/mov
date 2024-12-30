using Moq;
using Mov.Core.Authorizers.Models.Entities;
using System;

namespace Mov.Core.Authorizers.Test.Builders
{
    internal class AccountRepositoryBuilder
    {
        #region field

        private readonly Mock<IAccountRepository> _mockRepository;

        #endregion field

        #region constructor

        public AccountRepositoryBuilder()
        {
            _mockRepository = new Mock<IAccountRepository>();
        }

        #endregion constructor

        #region method

        public IAccountRepository Build()
        {
            return _mockRepository.Object;
        }

        public AccountRepositoryBuilder WithGetByNameCalled(string name, Account account)
        {
            _mockRepository
                .Setup(x => x.GetByName(name))
                .Returns(account)
                .Callback(() =>
                {
                    Console.WriteLine(account.ToString());
                });
            return this;
        }

        #endregion method
    }
}
