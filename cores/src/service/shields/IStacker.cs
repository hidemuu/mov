namespace Mov.Core.Shields
{
    public interface IStacker
    {
        string GetName();
        void Insert(int row, int col);
        void Eject(int row, int col);
    }
}
