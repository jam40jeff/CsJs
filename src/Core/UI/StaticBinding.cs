namespace MorseCode.CsJs.UI
{
    public class StaticBinding : IBinding
    {
        public static readonly StaticBinding Instance = new StaticBinding();

        private StaticBinding()
        {
        }

        public void Dispose()
        {
        }
    }
}