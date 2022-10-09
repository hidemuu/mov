using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Driver.Models
{
    public interface IMeasurable
    {
        void WriteMeasurement(TextWriter writer);
    }
}
