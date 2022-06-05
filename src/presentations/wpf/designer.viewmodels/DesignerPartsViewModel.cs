using Mov.Designer.Models.interfaces;
using Mov.Designer.Service;
using Mov.Designer.Service.Layouts;
using Mov.Designer.Service.Layouts.Nodes;
using Mov.Designer.ViewModels.Models;
using Mov.WpfViewModels;
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

        private LayoutBuilder layoutBuilder;

        #endregion フィールド

        #region プロパティ

        public ReactiveCollection<LayoutNodeBase> Models { get; } = new ReactiveCollection<LayoutNodeBase>();

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DesignerPartsViewModel(IDesignerRepositoryCollection repository)
        {
            layoutBuilder = new LayoutBuilder(repository);
            var node = layoutBuilder.Build().Layout.Children;
            Models.AddRangeOnScheduler(node);
        }

        #endregion コンストラクター

        #region メソッド

        #endregion メソッド

        #region 内部メソッド

        #endregion 内部メソッド
    }
}
