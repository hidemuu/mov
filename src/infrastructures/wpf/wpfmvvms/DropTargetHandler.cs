using GongSolutions.Wpf.DragDrop;
using Mov.WpfControls.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfMvvms
{
    public class DropTargetHandler<T> : IDropTarget where T : DragDropViewModelBase
    {
        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.VisualTarget == dropInfo.DragInfo.VisualSource)    // 同じItemのときはDropしません
            {
                dropInfo.NotHandled = dropInfo.VisualTarget == dropInfo.DragInfo.VisualSource;
            }
            else
            {
                dropInfo.DropTargetAdorner = typeof(DropTargetHighlightAdorner);
                dropInfo.Effects = DragDropEffects.Move;
            }

        }

        public void Drop(IDropInfo dropInfo)
        {
            if (dropInfo.VisualTarget == dropInfo.DragInfo.VisualSource)    // 同じItemのときはDropしません
            {
                dropInfo.NotHandled = dropInfo.VisualTarget == dropInfo.DragInfo.VisualSource;
            }
            else
            {
                int? targetId = null;
                string targetText = null;

                // Drop先のデータ処理
                foreach (var child in ((TreeListView)dropInfo.VisualTarget).Items)
                {
                    if (child.GetType().Equals(typeof(TextBlock)))
                    {
                        // コントロールのDataContextにアクセスして値をセットする
                        //if (((TextBlock)child).Name == "SampleId")
                        //{
                        //    targetId = ((SampleItem)((TextBlock)child).DataContext).SampleId;
                        //    ((SampleItem)((TextBlock)child).DataContext).SampleId = ((SampleItem)dropInfo.Data).SampleId;
                        //}

                        //if (((TextBlock)child).Name == "SampleText")
                        //{
                        //    targetText = ((SampleItem)((TextBlock)child).DataContext).SampleText;
                        //    ((SampleItem)((TextBlock)child).DataContext).SampleText = ((SampleItem)dropInfo.Data).SampleText;
                        //}
                    }
                }
                //((TreeListView)dropInfo.VisualTarget).DataContext.IsDragSource = true;

                // Drag元のデータ処理
                if (targetId != null)
                {
                    // Darg先と入れ替え
                    //((SampleItem)dropInfo.DragInfo.SourceItem).SampleId = targetId;
                    //((SampleItem)dropInfo.DragInfo.SourceItem).SampleText = targetText;
                    ((T)dropInfo.DragInfo.SourceItem).IsDragSource.Value = true;
                }
                else
                {
                    // Drag元を空にする
                    //((SampleItem)dropInfo.DragInfo.SourceItem).SampleId = null;
                    //((SampleItem)dropInfo.DragInfo.SourceItem).SampleText = "(なし)";
                    ((T)dropInfo.DragInfo.SourceItem).IsDragSource.Value = false;
                }
            }
        }
    }
}
