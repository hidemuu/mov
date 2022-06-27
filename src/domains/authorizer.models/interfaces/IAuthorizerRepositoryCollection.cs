using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Authorizer.Models
{
    public interface IAuthorizerRepositoryCollection
    {
        DbObjectRepositoryBase<User, UserCollection> Users { get; }
    }
}
