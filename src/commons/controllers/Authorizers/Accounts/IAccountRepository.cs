using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Authorizers
{
    public interface IAccountRepository
    {
        Account GetByName(string name);
    }
}
