using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Nodes.ValueObjects
{
    public sealed class NodeControlType : ValueObjectBase<NodeControlType>
    {
        #region オブジェクト

        public static readonly NodeControlType Label = new NodeControlType(ControlType.Label);

        public static readonly NodeControlType Button = new NodeControlType(ControlType.Button);

        public static readonly NodeControlType RadioButton = new NodeControlType(ControlType.RadioButton);

        public static readonly NodeControlType SpinBox = new NodeControlType(ControlType.SpinBox);

        public static readonly NodeControlType TextBox = new NodeControlType(ControlType.TextBox);

        public static readonly NodeControlType ListBox = new NodeControlType(ControlType.ListBox);
        
        public static readonly NodeControlType ComboBox = new NodeControlType(ControlType.ComboBox);

        public static readonly NodeControlType CheckBox = new NodeControlType(ControlType.CheckBox);

        public static readonly NodeControlType DatePicker = new NodeControlType(ControlType.DatePicker);

        #endregion オブジェクト

        #region プロパティ

        public ControlType Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public NodeControlType(ControlType controlType)
        {
            this.Value = controlType;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(NodeControlType other)
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
