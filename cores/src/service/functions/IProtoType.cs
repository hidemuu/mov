namespace Mov.Core.Functions
{
    public interface IProtoType<T> where T : new()
    {
        T DeepCopy();
    }
}
