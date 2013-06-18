namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
	public abstract class StopwatchControlBase<T> : global::MorseCode.CsJs.UI.Controls.MarkupControlBase<T>
	{
		protected global::MorseCode.CsJs.UI.Controls.DropDown @_viewModeDropDown { get { return FindControl<global::MorseCode.CsJs.UI.Controls.DropDown>("_viewModeDropDown"); } }
		protected global::MorseCode.CsJs.UI.Controls.Label @_timeLabel { get { return FindControl<global::MorseCode.CsJs.UI.Controls.Label>("_timeLabel"); } }
		protected global::MorseCode.CsJs.UI.Controls.Button @_startButton { get { return FindControl<global::MorseCode.CsJs.UI.Controls.Button>("_startButton"); } }
		protected global::MorseCode.CsJs.UI.Controls.Button @_stopButton { get { return FindControl<global::MorseCode.CsJs.UI.Controls.Button>("_stopButton"); } }
		protected global::MorseCode.CsJs.UI.Controls.Button @_resetButton { get { return FindControl<global::MorseCode.CsJs.UI.Controls.Button>("_resetButton"); } }

		protected override string Markup
		{
			get
			{
				return
@"<declare type=""StopwatchControl"" />

<div style=""background-color: black; padding: 75px;"">
  <div>
    <control type=""MorseCode.CsJs.UI.Controls.DropDown"" controlid=""_viewModeDropDown"" />
  </div>
  <div>
    <control type=""MorseCode.CsJs.UI.Controls.Label"" controlid=""_timeLabel"" style=""color: rgb(128,0,0); font-family: Arial; font-size: 96pt;"" />
  </div>
  <div>
    <control type=""MorseCode.CsJs.UI.Controls.Button"" controlid=""_startButton"" text=""Start"" style=""padding-right: 5px;"" />
    <control type=""MorseCode.CsJs.UI.Controls.Button"" controlid=""_stopButton"" text=""Stop"" style=""padding-right: 5px;"" />
    <control type=""MorseCode.CsJs.UI.Controls.Button"" controlid=""_resetButton"" text=""Reset"" />
  </div>
</div>";
			}
		}
	}
}
