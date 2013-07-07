<control classname="MorseCode.CsJs.Examples.CalculatorsAndStopwatch.UI.CalculatorControl">
  <control type="MorseCode.CsJs.UI.Controls.Panel" style="padding: 15px; background-color: rgb(255,255,192);">
    <control type="MorseCode.CsJs.UI.Controls.Label" text="Update In Real-Time: " />
    <control type="MorseCode.CsJs.UI.Controls.DropDown" controlid="_updateInRealTime" style="color: red;" />
  </control>
  <control type="MorseCode.CsJs.UI.Controls.Panel" controlid="_simulateLatencyPanel" style="padding: 15px; background-color: rgb(192,192,255);">
    <control type="MorseCode.CsJs.UI.Controls.Label" text="Simulate Latency: " />
    <control type="MorseCode.CsJs.UI.Controls.DropDown" controlid="_simulateLatency" />
  </control>
  <control type="MorseCode.CsJs.UI.Controls.Panel" style="padding: 15px; background-color: rgb(128,128,128);">
    <control type="MorseCode.CsJs.UI.Controls.DropDown" controlid="_function" skincategory="Lighter" />
  </control>
  <control type="MorseCode.CsJs.UI.Controls.Panel" style="padding: 15px; background-color: rgb(192,192,192);">
    <control type="MorseCode.CsJs.UI.Controls.TextBox" controlid="_operand1" />
    <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_operator" style="padding-left: 5px; padding-right: 5px;" />
    <control type="MorseCode.CsJs.UI.Controls.TextBox" controlid="_operand2" />
    <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_equals" style="padding-left: 5px;" />
    <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_result" style="padding-left: 5px;" />
  </control>
  <control type="MorseCode.CsJs.UI.Controls.Panel" controlid="_largeResultPanel" style="border: 1px dashed gray;">
    <table style="width: 100%;">
      <tr>
        <td style="height: 150px; vertical-align: middle; text-align: center;">
          <control type="MorseCode.CsJs.UI.Controls.Label" controlid="_largeResultLabel" style="font-family: Arial;" />
        </td>
      </tr>
    </table>
  </control>
</control>