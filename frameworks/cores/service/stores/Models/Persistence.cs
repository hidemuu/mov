using System.IO;

namespace Mov.Core.Stores.Models
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
