using Mov.Layouts;
using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class NullLayoutContent : ILayoutContent
    {
        public ContentCode Code => new ContentCode(string.Empty);

        public ContentName Name => throw new NotImplementedException();

        public ContentControlType ControlType => throw new NotImplementedException();

        public ContentIcon Icon => throw new NotImplementedException();

        public ContentIndent Indent => throw new NotImplementedException();

        public ContentWidth Width => throw new NotImplementedException();

        public ContentVisibility Visibility => throw new NotImplementedException();

        public ContentEnable Enable => throw new NotImplementedException();

        public ContentOrientation Orientation => throw new NotImplementedException();

        public ContentHorizontalAlignment HorizontalAlignment => throw new NotImplementedException();

        public ContentVerticalAlignment VerticalAlignment => throw new NotImplementedException();

        public ContentHeight Height => throw new NotImplementedException();

        public ContentSchema Schema => throw new NotImplementedException();

        public ContentValue ContentValue => throw new NotImplementedException();

        public ContentMacro Macro => throw new NotImplementedException();

        public ContentParameter Parameter => throw new NotImplementedException();
    }
}
