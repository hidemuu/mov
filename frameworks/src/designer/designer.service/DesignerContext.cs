using Mov.Core.Documents;
using Mov.Core.Layouts;
using Mov.Core.Layouts.Models;
using Mov.Core.Layouts.Models.Contents;
using Mov.Core.Layouts.Models.Nodes;
using Mov.Core.Layouts.Models.Shells;
using Mov.Core.Layouts.Models.Themes;
using Mov.Core.Maths;
using Mov.Core.Models;
using Mov.Core.Styles.Models;
using Mov.Core.Valuables;
using Mov.Core.Valuables.Sizes;
using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Designer.Service
{
    public class DesignerContext : ILayoutContext
    {
        private readonly IDesignerRepository repository;

        public Identifier<string> DomainId { get; }

        public IEnumerable<LayoutNode> Nodes { get; } = new List<LayoutNode>();

        public IEnumerable<LayoutContent> Contents { get; } = new List<LayoutContent>();

        public IEnumerable<LayoutShell> Shells { get; } = new List<LayoutShell>();

        public IEnumerable<LayoutTheme> Themes { get; } = new List<LayoutTheme>();

        public DesignerContext(IDesignerRepository repository)
        {
            this.repository = repository;
            DomainId = new Identifier<string>(repository.Endpoint);
            Nodes = GetNodes(repository);
            Contents = GetContents(repository);
            Shells = GetShells(repository);
            Themes = GetThemes(repository);
        }

        private IEnumerable<LayoutNode> GetNodes(IDesignerRepository repository)
        {
            var task = repository.Nodes.GetsAsync();
            Task.WhenAll(task);
            return GetNode(task.Result, repository);
        }

        private IEnumerable<LayoutNode> GetNode(IEnumerable<NodeSchema> nodes, IDesignerRepository repository)
        {
            var result = new List<LayoutNode>();
            foreach (var node in nodes)
            {
                var task = repository.Contents.GetAsync(node.Id);
                Task.WhenAll(task);
                var parent = new LayoutNode(
                    new Identifier<string>(node.Code), new NodeStyle(node.NodeType), new EnableStyle(true),
                    GetContent(task.Result));
                parent.AddRange(GetNode(node.Children, repository));
                result.Add(parent);
            }
            return result;
        }

        private IEnumerable<LayoutContent> GetContents(IDesignerRepository repository)
        {
            var task = repository.Contents.GetsAsync();
            Task.WhenAll(task);
            foreach (var content in task.Result)
            {
                yield return GetContent(content);
            }
        }

        private LayoutContent GetContent(ContentSchema content)
        {
            return new LayoutContent(
                        new LayoutContentKey(new Identifier<string>(content.Code), new ControlStyle(content.ControlType)),
                        new LayoutContentStatus(new Document(content.Name), new IconImage(content.Icon), VisibilityStyle.Visible, EnableStyle.Enable, new Parameter(content.Parameter)),
                        new LayoutContentArrange(MarginValue.Default, new Size2D(content.Width, content.Height), OrientationStyle.Horizontal, new HorizontalAlignmentStyle(content.HorizontalAlignment), new VerticalAlignmentStyle(content.VerticalAlignment)),
                        new LayoutContentValue(new LayoutValue(content.Schema), new Variable(content.DefaultValue), new Macro(content.Macro)));
        }

        private IEnumerable<LayoutShell> GetShells(IDesignerRepository repository)
        {
            foreach (var shell in Task.WhenAll(repository.Shells.GetsAsync()).Result[0])
            {
                yield return new LayoutShell(RegionStyle.Center, ColorStyle.Transrarent, ColorStyle.Transrarent, ThicknessValue.Default, Size2D.Default);
            }
        }

        private IEnumerable<LayoutTheme> GetThemes(IDesignerRepository repository)
        {
            foreach (var theme in Task.WhenAll(repository.Themes.GetsAsync()).Result[0])
            {
                yield return new LayoutTheme(ThemeStyle.Light);
            }
        }

        public void Read()
        {
            Task.WhenAll(repository.Nodes.GetsAsync());
            Task.WhenAll(repository.Contents.GetsAsync());
            Task.WhenAll(repository.Shells.GetsAsync());
        }

        public void Write()
        {

        }

        public void Update()
        {
        }
    }
}