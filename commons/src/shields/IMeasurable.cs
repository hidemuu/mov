using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Shields
{
    public interface IMeasurable
    {
        void WriteMeasurement(TextWriter writer);
    }
}
