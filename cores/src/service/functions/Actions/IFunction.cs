namespace Mov.Core.Templates.Actions
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
