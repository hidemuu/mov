using Mov.Core.Contexts.Structures;
using Mov.Core.Models.Units;
using Mov.Core.Translators.Models.Entities;
using Mov.Core.Translators.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Translators.Contexts
{
    public sealed class TranslatorContext : IDisposable
    {
        #region field

        private readonly static Stack<TranslatorContext> stack = new Stack<TranslatorContext>();

        #endregion field

        #region property

        public LocalizeContent Content { get; } = LocalizeContent.Empty;

        #endregion property

        #region constructor

        public TranslatorContext(LocalizeContent content)
        {
            this.Content = content;
            stack.Push(this);
        }

        static TranslatorContext()
        {
            // ensure there's at least one state
            stack.Push(new TranslatorContext(LocalizeContent.Empty));
        }

        public static TranslatorContext Current => stack.Peek();

        #endregion constructor

        #region method

        public void Dispose()
        {
            if (stack.Count > 1)
                stack.Pop();
        }

        #endregion method
    }
}
