using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Authorizers
{
    public interface IAuthorized
    {
        void ChangePassword(string oldPassword, string newPassword);

        void AddToBasket(Guid itemID);

        void Checkout();

        void Logout();
    }
}
