namespace Mov.Core.Templates.Repositories
{
    public interface IFileRepository<TBody>
    {
        /// <summary>
        /// インポート
        /// </summary>
        TBody Read();

        /// <summary>
        /// エクスポート
        /// </summary>
        void Write();
    }
}
