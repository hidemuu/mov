using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.ValueObjects
{
    public sealed class ContentIcon : ValueObjectBase<ContentIcon>
    {

        public string Value { get; }

        public ContentIcon(string url)
        {
            this.Value = url;
        }

        protected override bool EqualCore(ContentIcon other)
        {
            throw new NotImplementedException();
        }
    }
}
