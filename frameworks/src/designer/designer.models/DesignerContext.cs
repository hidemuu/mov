using Mov.Designer.Models.Schemas;
using Mov.Layouts;
using Mov.Layouts.Models;
using Mov.Layouts.Models.Entities;
using Mov.Layouts.Models.Entities.Contents;
using Mov.Layouts.Models.Styles;
using Mov.Utilities.Models.ValueObjects;
using Mov.Utilities.Models.ValueObjects.Keys;
using Mov.Utilities.Models.ValueObjects.Styles;
using Mov.Utilities.Models.ValueObjects.Units;
using Mov.Utilities.Models.ValueObjects.Units.Sizes;
using System.Collections.Generic;

namespace Mov.Designer.Models
{
    public class DesignerContext : ILayoutContext
    {
        private readonly IDesignerRepository repository;

        public CodeKey DomainId { get; }

        public IEnumerable<LayoutNode> Nodes { get; } = new List<LayoutNode>();

        public IEnumerable<LayoutContent> Contents { get; } = new List<LayoutContent>();

        public IEnumerable<LayoutShell> Shells { get; } = new List<LayoutShell>();

        public IEnumerable<LayoutTheme> Themes { get; } = new List<LayoutTheme>();

        public DesignerContext(IDesignerRepository repository)
        {
            this.repository = repository;
            this.DomainId = new CodeKey(repository.DomainPath);
            this.Nodes = GetNodes(repository);
            this.Contents = GetContents(repository);
            this.Shells = GetShells(repository);
            this.Themes = GetThemes(repository);
        }

        private IEnumerable<LayoutNode> GetNodes(IDesignerRepository repository)
        {
            return GetNode(repository.Nodes.Get(), repository);
        }

        private IEnumerable<LayoutNode> GetNode(IEnumerable<NodeSchema> nodes, IDesignerRepository repository)
        {
            var result = new List<LayoutNode>();
            foreach (var node in nodes)
            {
                var parent = new LayoutNode(
                    new CodeKey(node.Code), new NodeStyle(node.NodeType), new EnableStyle(true),
                    GetContent(repository.Contents.Get(node.Code)));
                parent.AddRange(GetNode(node.Children, repository));
                result.Add(parent);
            }
            return result;
        }

        private IEnumerable<LayoutContent> GetContents(IDesignerRepository repository)
        {
            foreach (var content in repository.Contents.Get())
            {
                yield return GetContent(content);
            }
        }

        private LayoutContent GetContent(ContentSchema content)
        {
            return new LayoutContent(
                        new LayoutContentKey(new CodeKey(content.Code), new ControlStyle(content.ControlType)),
                        new LayoutContentStatus(new Info(content.Name), new IconImage(content.Icon), VisibilityStyle.Visible, EnableStyle.Enable, new Parameter(content.Parameter)),
                        new LayoutContentArrange(MarginUnit.Default, new Size2D(content.Width, content.Height), OrientationStyle.Horizontal, new HorizontalAlignmentStyle(content.HorizontalAlignment), new VerticalAlignmentStyle(content.VerticalAlignment)),
                        new LayoutContentSchema(new LayoutSchema(content.Schema), new Variable(content.DefaultValue), new Macro(content.Macro)));
        }

        private IEnumerable<LayoutShell> GetShells(IDesignerRepository repository)
        {
            foreach (var shell in repository.Shells.Get())
            {
                yield return new LayoutShell(RegionStyle.Center, ColorStyle.Transrarent, ColorStyle.Transrarent, ThicknessUnit.Default, Size2D.Default);
            }
        }

        private IEnumerable<LayoutTheme> GetThemes(IDesignerRepository repository)
        {
            foreach (var theme in repository.Themes.Get())
            {
                yield return new LayoutTheme(ThemeStyle.Light);
            }
        }

        public void Read()
        {
            this.repository.Nodes.Read();
            this.repository.Contents.Read();
            this.repository.Shells.Read();
        }

        public void Write()
        {
            this.repository.Nodes.Write();
            this.repository.Contents.Write();
            this.repository.Shells.Write();
        }

        public void Update()
        {
        }
    }
}