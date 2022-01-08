using System;
using System.Collections.Generic;
using System.Text;

namespace Authorizer.Models
{
    public interface IAuthorizerRepository
    {
        IUserRepository Users { get; }
    }
}
