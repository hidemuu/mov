using System.IO;

namespace Mov.Core.Shields
{
    public interface IMeasurable
    {
        void WriteMeasurement(TextWriter writer);
    }
}
