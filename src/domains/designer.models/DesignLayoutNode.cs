﻿using Mov.Designer.Models;
using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.Contexts;
using Mov.Layouts.Nodes.ValueObjects;
using Mov.Schemas.Keys;
using Reactive.Bindings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models
{
    public class DesignLayoutNode : LayoutNode
    {
        public static DesignLayoutNode Default = new DesignLayoutNode(new Node(), new Content());

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="node"></param>
        /// <param name="content"></param>
        public DesignLayoutNode(Node node, Content content) 
            : base(new CodeKey(node.Code), new NodeStyle(node.NodeType), new EnableStyle(true), new DesignLayoutContent(content))
        {
            
        }

        #endregion コンストラクター

        
    }
}