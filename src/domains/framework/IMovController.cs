namespace Mov.Framework
{
    public interface IMovController
    {
        bool SetDomain(string domainTypeString);

        bool ExecuteDomainCommand(string command, string[] args);

        bool ExecuteCommand(DomainType domainType, string command, string[] args);

        bool ExecuteCommand(string domainTypeString, string command, string[] args);

        bool ExistsDomainCommand(string command);

        bool ExistsCommand(DomainType domainType, string command);

        bool ExistsCommand(string domainTypeString, string command);

        string GetDomainCommandHelp();

        string GetCommandHelp(DomainType domainType);

        string GetCommandHelp(string domainTypeString);

        string GetDomainHelp();
    }
}