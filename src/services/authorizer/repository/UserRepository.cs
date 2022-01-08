using Mov.Accessors;
using Mov.Authorizer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Authorizer.Repository
{
    public class UserRepository : FileAccessor<User>, IUserRepository
    {
        public readonly static string FILE_NAME = "user";
        public UserRepository(IFileHelper fileHelper) : base(fileHelper)
        {

        }
    }
}
