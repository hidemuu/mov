using Mov.Designer.Service.Layouts;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Designer.ViewModels.Models
{
    public class DesignerPartsModel : BindableBase, IEnumerable<DesignerPartsModel>
    {
        #region フィールド

        /// <summary>
        /// 子階層
        /// </summary>
        private List<DesignerPartsModel> children = new List<DesignerPartsModel>();

        #endregion フィールド

        #region プロパティ

        /// <summary>
        /// 名称
        /// </summary>
        public ReactivePropertySlim<string> Name { get; } = new ReactivePropertySlim<string>("TBD");

        /// <summary>
        /// 子階層
        /// </summary>
        public List<DesignerPartsModel> Children => children;

        #endregion プロパティ

        #region コンストラクター

        public DesignerPartsModel()
        {

        }

        public DesignerPartsModel(LayoutNodeBase node)
        {
            Name.Value = node.Name;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerator<DesignerPartsModel> GetEnumerator()
        {
            return (IEnumerator<DesignerPartsModel>)children;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(DesignerPartsModel model)
        {
            children.Add(model);
        }

        public void AddRange(IEnumerable<DesignerPartsModel> models)
        {
            children.AddRange(models);
        }

        #endregion メソッド

    }
}
