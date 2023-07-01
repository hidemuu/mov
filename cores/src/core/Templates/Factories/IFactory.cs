namespace Mov.Core.Templates.Factories
{
    public interface IFactory<TInstance>
    {
        TInstance Create(string param);
    }
}
