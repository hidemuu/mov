using Mov.Core.Models.Texts;

namespace Mov.Core.Shields
{
    public interface IScanner
    {
        void Scan(Document document);
    }
}