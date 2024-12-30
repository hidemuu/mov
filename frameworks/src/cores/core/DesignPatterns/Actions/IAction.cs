namespace Mov.Core.DesignPatterns.Actions
{
    /// <summary>
    /// アクションのインターフェース（戻り値なし）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAction<TParameter>
    {
        void Invoke(TParameter parameter);
    }
}
