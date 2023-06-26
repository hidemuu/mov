using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Utilities.Models.Entities
{
    public class Persistence<T>
    {
        public void SaveToFile(Journal<T> journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }
}
