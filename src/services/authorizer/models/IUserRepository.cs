using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authorizer.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> Gets();
    }
}
