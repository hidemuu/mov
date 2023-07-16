using Mov.Core.Models.Keys;
using Mov.Core.Models.Locations;
using Mov.Core.Translators.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Core.Translators.Models.Entities
{
    public class LocalizeContent
    {
        #region property

        public Identifier Id { get; }

        public IdentifierIndex Index { get; }

        public IdentifierCode Code { get; }

        public IEnumerable<LocalizeInfo> Infos { get; } = new HashSet<LocalizeInfo>();

        #endregion property

        #region constructor

        public LocalizeContent(Identifier identifier, IdentifierIndex index, IdentifierCode code, IEnumerable<LocalizeInfo> infos)
        {
            this.Id = identifier;
            this.Index = index;
            this.Code = code;
            this.Infos = infos;
        }

        public static readonly LocalizeContent Empty = new LocalizeContent(Identifier.Empty, IdentifierIndex.Empty, IdentifierCode.Empty, new[] { LocalizeInfo.Empty });

        #endregion constructor

        #region method

        public LocalizeInfo Get(Language location)
        {
            return Infos.FirstOrDefault(x => x.Location.Equals(location));
        }

        #endregion method
    }
}
