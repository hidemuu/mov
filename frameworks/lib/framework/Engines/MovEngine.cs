namespace Mov.Framework.Engines
{
    public class MovEngine : IMovEngine
    {
        public int DomainId { get; }
        public IMovService Service { get; }

        public MovEngine(int domainId, IMovService service)
        {
            DomainId = domainId;
            Service = service;
        }
    }
}