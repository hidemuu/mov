using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Styles
{
    public sealed class ControlStyle : ValueObjectBase<ControlStyle>
    {
        #region オブジェクト

        public static readonly ControlStyle Label = new ControlStyle("Label");

        public static readonly ControlStyle Button = new ControlStyle("Button");

        public static readonly ControlStyle RadioButton = new ControlStyle("RadioButton");

        public static readonly ControlStyle SpinBox = new ControlStyle("SpinBox");

        public static readonly ControlStyle TextBox = new ControlStyle("TextBox");

        public static readonly ControlStyle ListBox = new ControlStyle("ListBox");

        public static readonly ControlStyle ComboBox = new ControlStyle("ComboBox");

        public static readonly ControlStyle CheckBox = new ControlStyle("CheckBox");

        public static readonly ControlStyle DatePicker = new ControlStyle("DatePicker");

        #endregion オブジェクト

        #region プロパティ

        public string Value { get; set; }

        public bool IsLabel => this == Label;

        public bool IsButton => this == Button;

        public bool IsRadioButton => this == RadioButton;

        public bool IsSpinBox => this == SpinBox;

        public bool IsTextBox => this == TextBox;

        public bool IsListBox => this == ListBox;

        public bool IsComboBox => this == ComboBox;

        public bool IsCheckBox => this == CheckBox;

        public bool IsDatePicker => this == DatePicker;

        #endregion プロパティ

        #region コンストラクター

        public ControlStyle(string controlType)
        {
            Value = controlType;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ControlStyle other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion メソッド

        #region 静的メソッド

        public static IEnumerable<string> GetStrings()
        {
            return new string[]
            {
                Label.Value,
                Button.Value,
                RadioButton.Value,
                SpinBox.Value,
                TextBox.Value,
                ListBox.Value,
                ComboBox.Value,
                CheckBox.Value,
                DatePicker.Value,
            };

        }

        #endregion 静的メソッド
    }
}
