using Mov.Accessors;
using Mov.Authorizer.Models;
using Mov.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Authorizer.Repository
{
    public class AuthorizerRepository : DomainRepositoryBase
    {
        public AuthorizerRepository(string dir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8) : base(extension)
        {
            Accounts = new DbObjectRepository<Account, AccountCollection>(dir, GetRelativePath("account"), encode);
        }

        public IDbObjectRepository<Account> Accounts { get; }
    }
}
