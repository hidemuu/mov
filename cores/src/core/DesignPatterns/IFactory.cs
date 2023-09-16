namespace Mov.Core.DesignPatterns
{
    public interface IFactory<TInstance>
    {
        TInstance Create(string param);
    }
}
