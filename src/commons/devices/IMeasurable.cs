using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Devices
{
    public interface IMeasurable
    {
        void WriteMeasurement(TextWriter writer);
    }
}
