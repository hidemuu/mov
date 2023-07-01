using Mov.Core.Helpers;
using System.IO;

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