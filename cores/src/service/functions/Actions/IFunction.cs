namespace Mov.Core.Functions.Actions
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
