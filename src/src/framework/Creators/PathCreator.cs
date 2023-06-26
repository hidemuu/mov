using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Mov.Framework
{
    public static class PathCreator
    {
        public static string GetSolutionPath() 
        {
            return PathHelper.GetCurrentRootPath(FrameworkConstants.SOLUTION_NAME); 
        }

        public static string GetResourcePath() => Path.Combine(GetSolutionPath(), FrameworkConstants.RESOURCE_NAME);
    }
}
