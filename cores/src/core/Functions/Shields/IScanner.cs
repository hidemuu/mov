using Mov.Core.Models.ValueObjects;

namespace Mov.Core.Functions.Shields
{
    public interface IScanner
    {
        void Scan(Document document);
    }
}