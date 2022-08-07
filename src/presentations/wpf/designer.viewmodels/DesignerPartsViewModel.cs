using Mov.Designer.Models;
using Mov.Designer.Service;
using Mov.Designer.Service.Nodes;
using Mov.WpfControls.ViewModels;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.ViewModels
{
    public class DesignerPartsViewModel : ViewModelBase
    {
        #region フィールド

        private LayoutBuilder builder;

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<LayoutNodeBase> Models { get; } = new ReactiveCollection<LayoutNodeBase>();

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DesignerPartsViewModel(IDesignerDatabase database)
        {
            builder = new LayoutBuilder(database.GetRepository(""));
        }

        #endregion コンストラクター

        #region イベント

        protected override void OnLoaded()
        {
            Models.Clear();
            Models.AddRangeOnScheduler(builder.Build().Layout.Children);
        }

        #endregion イベント

        #region 内部メソッド

        #endregion 内部メソッド
    }
}
