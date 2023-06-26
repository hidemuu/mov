namespace Mov.Framework.Controllers
{
    public class MovEngine : IMovEngine
    {
        public int DomainId { get; }
        public IMovService Service { get; }

        public MovEngine(int domainId, IMovService service)
        {
            this.DomainId = domainId;
            this.Service = service;
        }
    }
}