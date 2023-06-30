namespace Mov.Core.Models
{
    public interface IProtoType<T> where T : new()
    {
        T DeepCopy();
    }
}
