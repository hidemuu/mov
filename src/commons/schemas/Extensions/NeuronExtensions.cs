using Mov.Schemas.Elements.Members.Learnings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Extensions
{
    public static class NeuronExtensions
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if (ReferenceEquals(self, other)) return;

            foreach (var from in self)
                foreach (var to in other)
                {
                    from.Out.Add(to);
                    to.In.Add(from);
                }
        }
    }
}
