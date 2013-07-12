using System;
using System.Linq.Expressions;
using MorseCode.CsJs.Common.Observable;
using MorseCode.CsJs.Common.Property;

namespace MorseCode.CsJs.UI.Controls.Grid
{
    public class GridBoundBooleanColumn<T> : GridBoundColumnBase<T, bool>, IGridBoundTextColumn<T, bool>
    {
        private GridBooleanBoundColumnDisplayMode _displayMode;
        private string _trueText = "Y";
        private string _falseText = "N";

        public GridBoundBooleanColumn(Expression<Func<T, IReadableObservableProperty<bool>>> propertyExpression)
            : base(propertyExpression)
        {
        }

        public GridBoundBooleanColumn(IPropertyExpression<T, IReadableObservableProperty<bool>> propertyExpression)
            : base(propertyExpression)
        {
        }

        public override IControl CreateControl(int rowIndex, T item)
        {
            if (DisplayMode == GridBooleanBoundColumnDisplayMode.CheckBox)
            {
                Label label = new Label();
                label.Text = "Checkbox coming soon!";
                return label;
            }
            else
            {
                Label label = new Label();
                label.BindText(new ReadOnlyProperty<T>(item), d => PropertyExpression.GetProperty(d), v => v ? TrueText : FalseText);
                return label;
            }
        }

        public GridBooleanBoundColumnDisplayMode DisplayMode
        {
            get
            {
                return _displayMode;
            }
            set
            {
                _displayMode = value;
                //TODO: refresh with templated control?
            }
        }

        public string TrueText
        {
            get
            {
                return _trueText;
            }
            set
            {
                _trueText = value;
                //TODO: refresh with templated control?
            }
        }

        public string FalseText
        {
            get
            {
                return _falseText;
            }
            set
            {
                _falseText = value;
                //TODO: refresh with templated control?
            }
        }
    }

    public enum GridBooleanBoundColumnDisplayMode
    {
        CheckBox,
        Text
    }
}