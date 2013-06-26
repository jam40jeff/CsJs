using System.Runtime.CompilerServices;
using jQueryApi;

namespace MorseCode.CsJs.Net
{
    public static class jQueryAjaxOptionsUtility
    {
        [InlineCode("{options}.data = {data};")]
        public static void SetDataString(jQueryAjaxOptions options, string data)
        {
        }
    }
}