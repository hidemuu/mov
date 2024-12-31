namespace Mov.Game.Service
{
    public interface IGameFacade
    {
        #region メソッド

        void Run();

        IGraphicGameService CreateGraphicGame();

        #endregion メソッド
    }
}