using Mov.Core.Documents.Models;

namespace Mov.Core.Shields
{
    public interface IScanner
    {
        void Scan(Document document);
    }
}