namespace Mov.Core.Templates
{
    public interface IProtoType<T> where T : new()
    {
        T DeepCopy();
    }
}
