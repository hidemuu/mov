using Mov.Core.Models.Keys;
using Mov.Core.Translators.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Translators.Models.Entities
{
    public class LocalizeContent
    {
        #region property

        public Identifier Id { get; }

        public LocalizeInfo EN { get; }

        public LocalizeInfo JP { get; }

        #endregion property

        #region constructor

        public LocalizeContent(Identifier identifier, LocalizeInfo en, LocalizeInfo jp)
        {
            this.Id = identifier;
            this.EN = en;
            this.JP = jp;
        }

        public static readonly LocalizeContent Empty = new LocalizeContent(Identifier.Empty, LocalizeInfo.Empty, LocalizeInfo.Empty);

        #endregion constructor
    }
}
