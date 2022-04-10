using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Authorizer.Models
{
    public interface IAuthorizerRepositoryCollection
    {
        FileRepositoryBase<User, UserCollection> Users { get; }
    }
}
