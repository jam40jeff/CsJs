using System;
using MorseCode.CsJs.Common.Observable;

namespace MorseCode.CsJs.UI.Controls.Grid
{
	public class GridButtonColumn<T> : GridColumnBase<T>
	{
		private readonly Action<IReadableObservableProperty<T>, Button> _setupButton;
		private readonly Func<T, Action> _clickAction;

		public GridButtonColumn(string uniqueName, Action<IReadableObservableProperty<T>, Button> setupButton, Func<T, Action> clickAction)
			: base(uniqueName)
		{
			_setupButton = setupButton;
			_clickAction = clickAction;
		}

		public override IControl CreateControl(int rowIndex, IReadableObservableProperty<T> item)
		{
			Button button = new Button();
			_setupButton(item, button);
			button.BindClickAction(item, _clickAction);
			return button;
		}
	}
}