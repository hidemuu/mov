namespace Mov.Core.Repositories.Services.Domains
{
    public interface IDomainRepository
    {
        /// <summary>
        /// ドメインの相対パス
        /// </summary>
        string DomainPath { get; }

        string RelativePath { get; }
    }
}
