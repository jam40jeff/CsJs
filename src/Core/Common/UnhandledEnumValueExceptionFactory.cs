using System;

namespace MorseCode.CsJs.Common
{
    public class UnhandledEnumValueException : Exception
    {
        public UnhandledEnumValueException()
        {
        }

        public UnhandledEnumValueException(string message)
            : base(message)
        {
        }

        public UnhandledEnumValueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public static class UnhandledEnumValueExceptionFactory
    {
        public static UnhandledEnumValueException Create<T>(T value) where T : struct
        {
            throw new UnhandledEnumValueException("An unhandled enum value was encountered for enum type " + typeof (T).FullName + ": " + value.EnumToString() + ".");
        }
    }
}