using Mov.Accessors;
using Mov.Authorizer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Authorizer.Repository
{
    public class UserRepository : FileRepositoryBase<User>, IUserRepository
    {
        public UserRepository(string path, string encoding = "utf-8") : base(path, encoding)
        {

        }
    }
}
