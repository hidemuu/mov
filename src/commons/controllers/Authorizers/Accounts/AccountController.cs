using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Authorizers
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
