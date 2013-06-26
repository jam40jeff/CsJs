using System.Runtime.CompilerServices;
using jQueryApi;

namespace MorseCode.CsJs.Net
{
    public static class jQueryXmlHttpRequestExtensionMethods
    {
        [InstanceMethodOnFirstArgument]
        public static jQueryXmlHttpRequest Done(this jQueryXmlHttpRequest o, params AjaxDoneCallback[] callbacks)
        {
            return null;
        }

        [InstanceMethodOnFirstArgument]
        public static jQueryXmlHttpRequest Fail(this jQueryXmlHttpRequest o, params AjaxFailCallback[] callbacks)
        {
            return null;
        }

        [InstanceMethodOnFirstArgument]
        public static jQueryXmlHttpRequest Then(this jQueryXmlHttpRequest o, AjaxDoneCallback doneCallback, AjaxFailCallback failCallback)
        {
            return null;
        }
    }

    //TODO: make textStatus an enum
    public delegate void AjaxDoneCallback(object data, string textStatus, jQueryXmlHttpRequest request);

    //TODO: make textStatus an enum
    public delegate void AjaxFailCallback(jQueryXmlHttpRequest request, string textStatus, string error);
}