using MorseCode.CsJs.UI.Controls;

namespace MorseCode.CsJs.UI
{
    public interface ISkin
    {
        void Apply(IControl control, string skinCategory);
    }
}