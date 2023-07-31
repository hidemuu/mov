using Mov.Core.Helpers;

namespace Mov.Core.Models.Connections
{
    public sealed class PathValue : ValueObjectBase<PathValue>
    {
        #region constant

        private const string RESOURCE_NAME = "resources";

        #endregion constant

        #region property

        public string Value { get; }

        #endregion property

        #region constructor

        public PathValue(string path) 
        {
            this.Value = path;
        }

        public static class Factory
        {
            public static PathValue CreateSolutionPath(string solutionName)
            {
                return new PathValue(PathHelper.GetCurrentRootPath(solutionName));
            }

            public static PathValue CreateResourcePath(string solutionName)
            {
                return new PathValue(System.IO.Path.Combine(PathHelper.GetCurrentRootPath(solutionName), RESOURCE_NAME));
            }

            public static PathValue CreateAssemblyPath()
            {
                return new PathValue(PathHelper.GetAssemblyRootPath());
            }
        }

        #endregion constructor

        #region method

        protected override bool EqualCore(PathValue other)
        {
            return this.Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion method
    }
}
