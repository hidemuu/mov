using Accessors;
using Designer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Designer.Repository.Xml
{
    public class DesignerRepository : IDesignerRepository
    {
        public DesignerRepository(string path, FileType fileType, string encoding = "utf-8")
        {
            switch (fileType)
            {
                case FileType.Json:
                    Layouts = new LayoutRepository(new JsonFileHelper(Path.Combine(path, LayoutRepository.FILE_NAME), encoding));
                    break;
                default:
                    Layouts = new LayoutRepository(new XmlFileHelper(Path.Combine(path, LayoutRepository.FILE_NAME), encoding));
                    break;
            }
        }

        public ILayoutRepository Layouts { get; }

    }
}
