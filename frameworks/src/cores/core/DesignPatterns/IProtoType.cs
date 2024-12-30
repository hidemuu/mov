namespace Mov.Core.DesignPatterns
{
    public interface IProtoType<T> where T : new()
    {
        T DeepCopy();
    }
}
