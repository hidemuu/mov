using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Functions
{
    public interface IMeasurable
    {
        void WriteMeasurement(TextWriter writer);
    }
}
