using Mov.Core.Authorizers.Models.Entities;

namespace Mov.Core.Authorizers
{
    public interface IAccountRepository
    {
        Account GetByName(string name);
    }
}
