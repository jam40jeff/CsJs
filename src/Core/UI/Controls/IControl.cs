using System;

namespace MorseCode.CsJs.UI.Controls
{
    public interface IControl : IDisposable
    {
        event EventHandler BeforeSkin;
        event EventHandler AfterSkin;
        event EventHandler AfterPostSkinMarkup;
    }
}