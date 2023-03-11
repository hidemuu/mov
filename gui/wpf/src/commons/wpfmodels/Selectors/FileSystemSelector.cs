using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfModels.Selectors
{
    public class FileSystemSelector : DataTemplateSelector
    {
        #region プロパティ

        public string DirectoryTemplate { get; set; }

        public string FileTemplate { get; set; }

        #endregion プロパティ

        #region メソッド

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var fileSystemInfo = (FileSystemInfo)item;
            string templateKey = (fileSystemInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory
                                ? DirectoryTemplate
                                : FileTemplate;

            return ((FrameworkElement)container).FindResource(templateKey) as DataTemplate;

        }

        #endregion メソッド
    }
}
