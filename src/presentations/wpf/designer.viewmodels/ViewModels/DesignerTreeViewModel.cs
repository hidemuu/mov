using Mov.Designer.Models;
using Mov.Designer.Models.interfaces;
using Mov.WpfViewModels;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.ViewModels
{
    public class DesignerTreeViewModel : ViewModelBase
    {
        #region フィールド

        private readonly IDesignerRepositoryCollection repository;

        #endregion

        #region プロパティ

        public ReactiveCollection<TreeModel> Models { get; } = new ReactiveCollection<TreeModel>();

        #endregion

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="repository"></param>
        public DesignerTreeViewModel(IDesignerRepositoryCollection repository)
        {
            this.repository = repository;
            foreach(var tree in repository.LayoutTrees.Gets())
            {
                Models.Add(new TreeModel(tree));
            }
        }

        #region イベント

        protected override void OnLoaded()
        {

        }

        #endregion

        #region クラス

        public class TreeModel
        {
            public ReactivePropertySlim<int> Id { get; } = new ReactivePropertySlim<int>();
            public ReactivePropertySlim<string> Code { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> LayoutType { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> LayoutStyle { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<string> LayoutParameter { get; } = new ReactivePropertySlim<string>();
            public ReactivePropertySlim<bool> IsExpand { get; } = new ReactivePropertySlim<bool>(true);
            public List<TreeModel> Children { get; set; } = new List<TreeModel>();

            public TreeModel(LayoutTree item)
            {
                Id.Value = item.Id;
                Code.Value = item.Code;
                IsExpand.Value = item.IsExpand;
                LayoutType.Value = item.LayoutType;
                LayoutStyle.Value = item.LayoutStyle;
                LayoutParameter.Value = item.LayoutParameter;
                foreach(var child in item.Children)
                {
                    Children.Add(new TreeModel(child));
                }
            }
        }

        #endregion
    }
}
