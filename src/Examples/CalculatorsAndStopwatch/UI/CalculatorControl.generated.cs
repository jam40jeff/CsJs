namespace MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI
{
	public abstract class CalculatorControlBase<T> : global::MorseCode.CsJs.UI.Controls.MarkupControlBase<T>
	{
		protected global::MorseCode.CsJs.UI.Controls.DropDown @_updateInRealTime { get { return FindControl<global::MorseCode.CsJs.UI.Controls.DropDown>("_updateInRealTime"); } }
		protected global::MorseCode.CsJs.UI.Controls.Panel @_simulateLatencyPanel { get { return FindControl<global::MorseCode.CsJs.UI.Controls.Panel>("_simulateLatencyPanel"); } }
		protected global::MorseCode.CsJs.UI.Controls.DropDown @_simulateLatency { get { return FindControl<global::MorseCode.CsJs.UI.Controls.DropDown>("_simulateLatency"); } }
		protected global::MorseCode.CsJs.UI.Controls.CheckBox @_useResultDelay { get { return FindControl<global::MorseCode.CsJs.UI.Controls.CheckBox>("_useResultDelay"); } }
		protected global::MorseCode.CsJs.UI.Controls.Label @_numberOfWebServiceRequestsSent { get { return FindControl<global::MorseCode.CsJs.UI.Controls.Label>("_numberOfWebServiceRequestsSent"); } }
		protected global::MorseCode.CsJs.UI.Controls.DropDown @_function { get { return FindControl<global::MorseCode.CsJs.UI.Controls.DropDown>("_function"); } }
		protected global::MorseCode.CsJs.UI.Controls.TextBox @_operand1 { get { return FindControl<global::MorseCode.CsJs.UI.Controls.TextBox>("_operand1"); } }
		protected global::MorseCode.CsJs.UI.Controls.Label @_operator { get { return FindControl<global::MorseCode.CsJs.UI.Controls.Label>("_operator"); } }
		protected global::MorseCode.CsJs.UI.Controls.TextBox @_operand2 { get { return FindControl<global::MorseCode.CsJs.UI.Controls.TextBox>("_operand2"); } }
		protected global::MorseCode.CsJs.UI.Controls.Label @_equals { get { return FindControl<global::MorseCode.CsJs.UI.Controls.Label>("_equals"); } }
		protected global::MorseCode.CsJs.UI.Controls.Label @_result { get { return FindControl<global::MorseCode.CsJs.UI.Controls.Label>("_result"); } }
		protected global::MorseCode.CsJs.UI.Controls.Panel @_largeResultPanel { get { return FindControl<global::MorseCode.CsJs.UI.Controls.Panel>("_largeResultPanel"); } }
		protected global::MorseCode.CsJs.UI.Controls.Label @_largeResultLabel { get { return FindControl<global::MorseCode.CsJs.UI.Controls.Label>("_largeResultLabel"); } }

		protected override string Markup
		{
			get
			{
				return
@"<control classname=""MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControl"">
  <control type=""MorseCode.CsJs.UI.Controls.Panel"" style=""padding: 15px; background-color: rgb(255,255,192);"">
    <control type=""MorseCode.CsJs.UI.Controls.Label"" text=""Update In Real-Time: "" />
    <control type=""MorseCode.CsJs.UI.Controls.DropDown"" controlid=""_updateInRealTime"" style=""color: red;"" />
  </control>
  <control type=""MorseCode.CsJs.UI.Controls.Panel"" controlid=""_simulateLatencyPanel"" style=""padding: 15px; background-color: rgb(192,192,255);"">
    <control type=""MorseCode.CsJs.UI.Controls.Label"" text=""Simulate Latency: "" />
    <control type=""MorseCode.CsJs.UI.Controls.DropDown"" controlid=""_simulateLatency"" />
    <control type=""MorseCode.CsJs.UI.Controls.CheckBox"" controlid=""_useResultDelay"" style=""margin-left: 25px;"" />
    <control type=""MorseCode.CsJs.UI.Controls.Label"" text="" Use Result Delay"" />
    <control type=""MorseCode.CsJs.UI.Controls.Label"" text=""Number Of Web Service Requests Sent: "" style=""padding-left: 25px;"" />
    <control type=""MorseCode.CsJs.UI.Controls.Label"" controlid=""_numberOfWebServiceRequestsSent"" />
  </control>
  <control type=""MorseCode.CsJs.UI.Controls.Panel"" style=""padding: 15px; background-color: rgb(128,128,128);"">
    <control type=""MorseCode.CsJs.UI.Controls.DropDown"" controlid=""_function"" skincategory=""Lighter"" />
  </control>
  <control type=""MorseCode.CsJs.UI.Controls.Panel"" style=""padding: 15px; background-color: rgb(192,192,192);"">
    <control type=""MorseCode.CsJs.UI.Controls.TextBox"" controlid=""_operand1"" />
    <control type=""MorseCode.CsJs.UI.Controls.Label"" controlid=""_operator"" style=""padding-left: 5px; padding-right: 5px;"" />
    <control type=""MorseCode.CsJs.UI.Controls.TextBox"" controlid=""_operand2"" />
    <control type=""MorseCode.CsJs.UI.Controls.Label"" controlid=""_equals"" style=""padding-left: 5px;"" />
    <control type=""MorseCode.CsJs.UI.Controls.Label"" controlid=""_result"" style=""padding-left: 5px;"" />
  </control>
  <control type=""MorseCode.CsJs.UI.Controls.Panel"" controlid=""_largeResultPanel"" style=""border: 1px dashed gray;"">
    <table style=""width: 100%;"">
      <tr>
        <td style=""height: 150px; vertical-align: middle; text-align: center;"">
          <control type=""MorseCode.CsJs.UI.Controls.Label"" controlid=""_largeResultLabel"" style=""font-family: Arial;"" />
        </td>
      </tr>
    </table>
  </control>
</control>";
			}
		}
	}
}
