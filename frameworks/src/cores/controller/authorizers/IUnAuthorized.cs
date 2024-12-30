namespace Mov.Core.Authorizers
{
    public interface IUnAuthorized
    {
        IAuthorized Login(string username, string password);

        void RequestPasswordReminder(string emailAddress);
    }
}
