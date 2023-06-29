using System;
using System.Collections.Generic;
using System.Linq;

namespace Mov.Core.Templates.Builders
{
    public abstract class FunctionalBuilderBase<TSubject, TSelf> : IBuilder<TSubject>
        where TSubject : new()
        where TSelf : FunctionalBuilderBase<TSubject, TSelf>
    {
        private readonly List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();

        public TSelf Do(Action<TSubject> action)
        {
            return AddAction(action);
        }

        public TSubject Build()
        {
            return actions.Aggregate(new TSubject(), (p, f) => f(p));
        }

        private TSelf AddAction(Action<TSubject> action)
        {
            actions.Add(p =>
            {
                action(p);
                return p;
            });
            return (TSelf)this;
        }
    }
}
