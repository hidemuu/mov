﻿using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service.Nodes
{
    public class ExpanderLayoutNode : LayoutNodeBase
    {
        public override LayoutNodeType LayoutNodeType => LayoutNodeType.Expander;

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ExpanderLayoutNode()
        {

        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ExpanderLayoutNode(LayoutNode layout) : base(layout)
        {

        }

        #endregion コンストラクター
    }
}