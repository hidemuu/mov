using Mov.Accessors;
using Mov.Accessors.Repository.Implement;
using Mov.Authorizer.Models;
using Mov.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Authorizer.Repository
{
    public class AuthorizerRepository : FileDomainRepositoryBase
    {
        public AuthorizerRepository(string dir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8) : base(dir, extension, encode)
        {
            Accounts = new DbObjectRepository<Account, AccountCollection>(dir, GetRelativePath("account"), encode);
        }

        public IDbObjectRepository<Account> Accounts { get; }
    }
}
