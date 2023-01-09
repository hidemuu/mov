using Autofac.Features.Metadata;
using Autofac;
using Mov.Schemas.Elements.Parameters.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Mov.Schemas.Elements.Parameters;

namespace Mov.Schemas.DesignPatterns.Structuals.Adapters.Commands
{
    public class CommandAdapter
    {
        public CommandAdapter() 
        {
            // for each ICommand, a ToolbarButton is created to wrap it, and all
            // are passed to the editor
            //var b = new ContainerBuilder();
            //b.RegisterType<OpenCommand>()
            //  .As<ICommand>()
            //  .WithMetadata("Name", "Open");
            //b.RegisterType<SaveCommand>()
            //  .As<ICommand>()
            //  .WithMetadata("Name", "Save");
            ////b.RegisterType<Button>();
            //b.RegisterAdapter<ICommand, Button>(cmd => new Button(cmd, ""));
            //b.RegisterAdapter<Meta<ICommand>, Button>(cmd =>
            //  new Button(cmd.Value, (string)cmd.Metadata["Name"]));
            //b.RegisterType<Editor>();
            //using (var c = b.Build())
            //{
            //    var editor = c.Resolve<Editor>();
            //    editor.ClickAll();

            //    // problem: only one button

            //    foreach (var btn in editor.Buttons)
            //        btn.PrintMe();


            //}
        }
    }
}
