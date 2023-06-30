namespace Mov.Core.Repositories.Services
{
    public interface IDomainRepository
    {
        /// <summary>
        /// ドメインの相対パス
        /// </summary>
        string DomainPath { get; }

        string GetRelativePath();
    }
}
