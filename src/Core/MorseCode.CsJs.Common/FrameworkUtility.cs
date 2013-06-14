using System;
using System.Runtime.CompilerServices;

namespace MorseCode.CsJs.Common
{
    [Imported(ObeysTypeSystem = true)]
    [ScriptNamespace("ss")]
    [ScriptName("Enum")]
    internal static class EnumImpl
    {
        public static string ToString(Type enumType, object value)
        {
            return null;
        }
    }

    public static class FrameworkUtility
    {
        public static T EnumParse<T>(string value) where T : struct
        {
            return (T)(object)Enum.Parse(typeof(T), value);
        }

        public static string EnumToString<T>(this T o) where T : struct
        {
            return EnumImpl.ToString(typeof(T), o);
        }

        public static string SafeToString(this object o)
        {
            return o == null ? null : o.ToString();
        }

        #region TryParse

        public static byte? ByteTryParse(string s)
        {
            byte b;
            try
            {
                b = byte.Parse(s);
            }
            catch
            {
                return null;
            }
            return IsNaN(b) ? (byte?)null : b;
        }

        [ScriptAlias("isNaN")]
// ReSharper disable UnusedParameter.Local
        private static bool IsNaN(byte b)
// ReSharper restore UnusedParameter.Local
        {
            return false;
        }

        public static short? ShortTryParse(string s)
        {
            short n;
            try
            {
                n = short.Parse(s);
            }
            catch
            {
                return null;
            }
            return IsNaN(n) ? (short?)null : n;
        }

        [ScriptAlias("isNaN")]
// ReSharper disable UnusedParameter.Local
        private static bool IsNaN(short s)
// ReSharper restore UnusedParameter.Local
        {
            return false;
        }

        public static int? IntTryParse(string s)
        {
            int i;
            try
            {
                i = int.Parse(s);
            }
            catch
            {
                return null;
            }
            return IsNaN(i) ? (int?)null : i;
        }

        [ScriptAlias("isNaN")]
// ReSharper disable UnusedParameter.Local
        private static bool IsNaN(int i)
// ReSharper restore UnusedParameter.Local
        {
            return false;
        }

        public static long? LongTryParse(string s)
        {
            long l;
            try
            {
                l = long.Parse(s);
            }
            catch
            {
                return null;
            }
            return IsNaN(l) ? (long?)null : l;
        }

        [ScriptAlias("isNaN")]
// ReSharper disable UnusedParameter.Local
        private static bool IsNaN(long l)
// ReSharper restore UnusedParameter.Local
        {
            return false;
        }

        public static float? FloatTryParse(string s)
        {
            float f;
            try
            {
                f = ParseFloat(s);
            }
            catch
            {
                return null;
            }
            return float.IsNaN(f) ? (float?)null : f;
        }

        [ScriptAlias("parseFloat")]
// ReSharper disable UnusedParameter.Local
        private static float ParseFloat(string s)
// ReSharper restore UnusedParameter.Local
        {
            return 0f;
        }

        public static double? DoubleTryParse(string s)
        {
            double d;
            try
            {
                d = double.Parse(s);
            }
            catch
            {
                return null;
            }
            return double.IsNaN(d) ? (double?)null : d;
        }

        public static decimal? DecimalTryParse(string s)
        {
            decimal d;
            try
            {
                d = ParseDecimal(s);
            }
            catch
            {
                return null;
            }
            return IsNaN(d) ? (decimal?)null : d;
        }

        [ScriptAlias("isNaN")]
// ReSharper disable UnusedParameter.Local
        private static bool IsNaN(decimal d)
// ReSharper restore UnusedParameter.Local
        {
            return false;
        }

        [ScriptAlias("parseFloat")]
// ReSharper disable UnusedParameter.Local
        private static decimal ParseDecimal(string s)
// ReSharper restore UnusedParameter.Local
        {
            return 0m;
        }

        #endregion TryParse

        [InlineCode("debugger;")]
        public static void Debugger()
        {
        }
    }
}