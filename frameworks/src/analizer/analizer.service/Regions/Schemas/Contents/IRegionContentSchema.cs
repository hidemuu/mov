using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Analizer.Service.Regions.Schemas.Contents
{
    public interface IRegionContentSchema
    {
        int Code { get; set; }

        string Name { get; set; }
    }
}
