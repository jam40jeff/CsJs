using System;
using System.Collections.Generic;
using System.Html;

namespace MorseCode.CsJs.UI.Controls
{
    public interface IControl : IDisposable
    {
        event EventHandler BeforeSkin;
        event EventHandler AfterSkin;
        event EventHandler AfterPostSkinMarkup;

        string Id { get; set; }
        string SkinCategory { get; set; }

        IEnumerable<Element> GetRootElementsInternal();
    }
}