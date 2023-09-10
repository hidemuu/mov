using Mov.Core.Locations;
using Mov.Core.Models.Identifiers;
using Mov.Core.Translators.Models.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Mov.Core.Translators.Models.Entities
{
    public class LocalizeContent
    {
        #region property

        public IdentifierIndex Index { get; }

        public IEnumerable<LocalizeInfo> Infos { get; } = new HashSet<LocalizeInfo>();

        #endregion property

        #region constructor

        public LocalizeContent(IdentifierIndex index, IEnumerable<LocalizeInfo> infos)
        {
            this.Index = index;
            this.Infos = infos;
        }

        public static readonly LocalizeContent Empty = new LocalizeContent(IdentifierIndex.Empty, new[] { LocalizeInfo.Empty });

        #endregion constructor

        #region method

        public LocalizeInfo Get(Language location)
        {
            return Infos.FirstOrDefault(x => x.Location.Equals(location));
        }

        #endregion method
    }
}
