namespace Mov.Core.Templates
{
    public interface IFactory<TInstance>
    {
        TInstance Create(string param);
    }
}
