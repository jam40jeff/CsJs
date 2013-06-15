using System;
using System.Web.UI;
using MorseCode.CsJs.UI;

namespace MorseCode.CsJs.Server.Web.UI
{
    public abstract class ApplicationPageBase<T> : Page where T : ApplicationBase, new()
    {
        //TODO: JAM: register scripts automatically

        protected bool IsDebug
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ClientScript.RegisterClientScriptBlock(typeof(ApplicationPageBase<T>), "Init", @"$(function() {
    new " + typeof(T).FullName + @"().initialize();
});", true);
        }
    }
}