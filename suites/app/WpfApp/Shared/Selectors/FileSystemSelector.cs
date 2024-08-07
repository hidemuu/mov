﻿using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Mov.Suite.WpfApp.Shared.Selectors
{
    public class FileSystemSelector : DataTemplateSelector
    {
        #region property

        public string DirectoryTemplate { get; set; }

        public string FileTemplate { get; set; }

        #endregion property

        #region method

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var fileSystemInfo = (FileSystemInfo)item;
            string templateKey = (fileSystemInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory
                                ? DirectoryTemplate
                                : FileTemplate;

            return ((FrameworkElement)container).FindResource(templateKey) as DataTemplate;

        }

        #endregion method
    }
}
