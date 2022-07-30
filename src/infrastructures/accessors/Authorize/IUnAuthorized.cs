using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Authorize
{
    public interface IUnAuthorized
    {
        IAuthorized Login(string username, string password);

        void RequestPasswordReminder(string emailAddress);
    }
}
