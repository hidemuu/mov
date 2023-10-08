namespace Mov.Game.Service
{
    public interface IGameFacade
    {
        #region メソッド

        void Run();

        IGraphicGame CreateGraphicGame();

        #endregion メソッド
    }
}