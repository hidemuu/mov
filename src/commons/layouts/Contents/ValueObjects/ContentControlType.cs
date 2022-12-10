using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contents.ValueObjects
{
    public sealed class ContentControlType : ValueObjectBase<ContentControlType>
    {
        #region オブジェクト

        public static readonly ContentControlType Label = new ContentControlType(ControlType.Label);

        public static readonly ContentControlType Button = new ContentControlType(ControlType.Button);

        public static readonly ContentControlType RadioButton = new ContentControlType(ControlType.RadioButton);

        public static readonly ContentControlType SpinBox = new ContentControlType(ControlType.SpinBox);

        public static readonly ContentControlType TextBox = new ContentControlType(ControlType.TextBox);

        public static readonly ContentControlType ListBox = new ContentControlType(ControlType.ListBox);
        
        public static readonly ContentControlType ComboBox = new ContentControlType(ControlType.ComboBox);

        public static readonly ContentControlType CheckBox = new ContentControlType(ControlType.CheckBox);

        public static readonly ContentControlType DatePicker = new ContentControlType(ControlType.DatePicker);

        #endregion オブジェクト

        #region プロパティ

        public ControlType Value { get; }

        #endregion プロパティ

        #region コンストラクター

        public ContentControlType(ControlType controlType)
        {
            this.Value = controlType;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentControlType other)
        {
            throw new NotImplementedException();
        }

        public bool IsLabel => this == Label;

        public bool IsButton => this == Button;

        public bool IsRadioButton => this == RadioButton;

        #endregion メソッド
    }
}
