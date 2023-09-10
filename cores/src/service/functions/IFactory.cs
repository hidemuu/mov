namespace Mov.Core.Functions
{
    public interface IFactory<TInstance>
    {
        TInstance Create(string param);
    }
}
