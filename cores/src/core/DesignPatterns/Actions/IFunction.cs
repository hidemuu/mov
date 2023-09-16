namespace Mov.Core.DesignPatterns.Actions
{
    /// <summary>
    /// ファンクションのインターフェース
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IFunction<TResult>
    {
        TResult Invoke();
    }
}
