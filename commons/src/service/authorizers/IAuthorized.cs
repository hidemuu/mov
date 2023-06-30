using System;

namespace Mov.Core.Authorizers
{
    public interface IAuthorized
    {
        void ChangePassword(string oldPassword, string newPassword);

        void AddToBasket(Guid itemID);

        void Checkout();

        void Logout();
    }
}
