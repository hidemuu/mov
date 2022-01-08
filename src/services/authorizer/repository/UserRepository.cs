using Accessors;
using Authorizer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authorizer.Repository
{
    public class UserRepository : FileAccessor<User>, IUserRepository
    {
        public readonly static string FILE_NAME = "user";
        public UserRepository(IFileHelper fileHelper) : base(fileHelper)
        {

        }
    }
}
