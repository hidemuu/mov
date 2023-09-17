using Mov.Core.Documents.Models;

namespace Mov.Core.Shields
{
    public interface IPrinter
    {
        void Print(Document document);
    }
}