using System;
using System.Collections.Generic;

namespace Mov.Core.Stores.Models
{
    public class Journal<T>
    {
        private readonly List<T> entries = new List<T>();

        private static int count = 0;

        public int Add(T entry)
        {
            entries.Add(entry);
            return count;
        }

        public void Remove(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }
}