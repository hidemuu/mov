using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Authorizer.Models
{
    public interface IAuthorizerRepository
    {
        IUserRepository Users { get; }
    }
}
