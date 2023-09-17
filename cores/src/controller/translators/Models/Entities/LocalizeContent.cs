using Mov.Core.Locations.Models;
using Mov.Core.Models;
using Mov.Core.Translators.Models.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Mov.Core.Translators.Models.Entities
{
    public class LocalizeContent
    {
        #region property

        public Identifier<int> Index { get; }

        public IEnumerable<LocalizeInfo> Infos { get; } = new HashSet<LocalizeInfo>();

        #endregion property

        #region constructor

        public LocalizeContent(Identifier<int> index, IEnumerable<LocalizeInfo> infos)
        {
            this.Index = index;
            this.Infos = infos;
        }

        public static readonly LocalizeContent Empty = new LocalizeContent(Identifier<int>.Empty, new[] { LocalizeInfo.Empty });

        #endregion constructor

        #region method

        public LocalizeInfo Get(Language location)
        {
            return Infos.FirstOrDefault(x => x.Location.Equals(location));
        }

        #endregion method
    }
}
