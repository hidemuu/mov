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
        public override string RelativePath => "authorizer";

        public AuthorizerRepository(string endpoint, string fileDir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8) : base(endpoint, fileDir, extension, encode)
        {
            Accounts = new FileDbObjectRepository<Account, AccountCollection>(GetPath("account"), encode);
        }

        public IDbObjectRepository<Account, AccountCollection> Accounts { get; }
    }
}
