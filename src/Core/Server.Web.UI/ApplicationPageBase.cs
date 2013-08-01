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

			ClientScript.RegisterClientScriptResource(typeof(ApplicationPageBase<>), "MorseCode.CsJs.Server.Web.UI.require.js");

			string requireModule = typeof(T).Assembly.GetName().Name;
			string requireInstance = requireModule.Replace('.', '$');
			ClientScript.RegisterClientScriptBlock(typeof(ApplicationPageBase<T>), "Init", @"requirejs.config({ baseUrl: 'Scripts' });
require(['jquery'], function($) {
	$(function() {
		require(['" + requireModule + @"'], function (" + requireInstance + @") {
			" + typeof(VirtualPathUtility).FullName + @".set_applicationRootPath('" + System.Web.VirtualPathUtility.ToAbsolute("~/").Replace("'", "\\'") + @"');
			new " + typeof(T).FullName + @"().initialize();
		});
	});
});", true);
		}
	}
}