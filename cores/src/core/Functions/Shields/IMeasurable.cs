using System.IO;

namespace Mov.Core.Functions.Shields
{
    public interface IMeasurable
    {
        void WriteMeasurement(TextWriter writer);
    }
}
