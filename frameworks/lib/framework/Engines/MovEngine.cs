namespace Mov.Framework.Engines
{
    public class MovEngine : IMovEngine
    {
        public int DomainId { get; }
        public IMovFacade Service { get; }

        public MovEngine(int domainId, IMovFacade service)
        {
            DomainId = domainId;
            Service = service;
        }
    }
}