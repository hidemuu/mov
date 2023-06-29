using Mov.Core.Models.ValueObjects;

namespace Mov.Core.Shields
{
    public interface IScanner
    {
        void Scan(Document document);
    }
}