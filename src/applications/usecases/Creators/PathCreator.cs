﻿using Mov.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Mov.UseCases.Creators
{
    public static class PathCreator
    {
        public static string GetSolutionPath() 
        {
            //var assembly = Assembly.GetEntryAssembly();
            //var rootPath = assembly.Location.TrimEnd(assembly.ManifestModule.Name.ToCharArray());
            return PathHelper.GetCurrentRootPath(UseCaseConstants.SOLUTION_NAME); 
        }

        public static string GetResourcePath() => Path.Combine(GetSolutionPath(), UseCaseConstants.RESOURCE_NAME);
    }
}