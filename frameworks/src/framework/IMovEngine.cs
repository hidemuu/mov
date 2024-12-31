namespace Mov.Framework
{
    public interface IMovEngine
    {
        #region プロパティ

        int DomainId { get; }

        IMovFacade Service { get; }

        #endregion プロパティ
    }
}