namespace Mov.Core.Authorizers.Services
{
    public class AccountController
    {
        private readonly IAccountService service;

        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        public void AddTransaction()
        {

        }
    }
}
