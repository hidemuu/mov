using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Suite.WpfApp.Shared.Models
{
    public class TabItemModel
    {
        #region constants

        private const string ICON_KEY_HOME = "Home";
        private const string ICON_KEY_DNS = "DNS";
        private const string ICON_KEY_CONFIG = "Config";
        private const string ICON_KEY_COLLAGE = "Collage";
        private const string ICON_KEY_BLUR = "blur";
        private const string ICON_KEY_SPROUT = "Sprout";
        private const string ICON_KEY_OCTAHEDRON = "Octahedron";
        private const string ICON_KEY_CALENDAR = "calendar";
        private const string ICON_KEY_CHARTLINE = "ChartLine";

        #endregion constants

        #region property

        public int Index { get; }
        public Action TabCommand { get; }

        public ReactivePropertySlim<string> Title { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<string> IconKey { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<bool> IsSelected { get; } = new ReactivePropertySlim<bool>();

        #endregion property

        #region constructor

        public TabItemModel(int index, string title, string iconkey, Action tabcommand) 
        {
            Index = index;
            TabCommand = tabcommand;
            Title.Value = title;
            IconKey.Value = iconkey;
        }

        #endregion constructor
    }
}
