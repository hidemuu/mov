namespace Mov.Core.DesignPatterns.Actions
{
    /// <summary>
    /// true / false判定のメソッドインターフェース
    /// </summary>
    public interface IPredicate
    {
        bool Invoke();
    }
}
