using Mov.Utilities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Contents.ValueObjects
{
    public sealed class ContentControlType : ValueObjectBase<ContentControlType>
    {
        #region オブジェクト

        public static readonly ContentControlType Label = new ContentControlType("Label");

        public static readonly ContentControlType Button = new ContentControlType("Button");

        public static readonly ContentControlType RadioButton = new ContentControlType("RadioButton");

        public static readonly ContentControlType SpinBox = new ContentControlType("SpinBox");

        public static readonly ContentControlType TextBox = new ContentControlType("TextBox");

        public static readonly ContentControlType ListBox = new ContentControlType("ListBox");
        
        public static readonly ContentControlType ComboBox = new ContentControlType("ComboBox");

        public static readonly ContentControlType CheckBox = new ContentControlType("CheckBox");

        public static readonly ContentControlType DatePicker = new ContentControlType("DatePicker");

        #endregion オブジェクト

        #region プロパティ

        public string Value { get; }

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

        public ContentControlType(string controlType)
        {
            this.Value = controlType;
        }

        #endregion コンストラクター

        #region メソッド

        protected override bool EqualCore(ContentControlType other)
        {
            return this.Value.Equals(other.Value);
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
