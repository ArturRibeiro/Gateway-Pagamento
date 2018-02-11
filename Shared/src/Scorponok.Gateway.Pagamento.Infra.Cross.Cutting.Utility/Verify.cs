using System;

namespace Scorponok.Shared.Utility
{
    public static class Verify
    {
        public static void ThrowIf<TException>(bool condition, Func<TException> init) where TException : Exception
        {
            if (!condition) return;

            var exception = init();

            throw exception;
        }
    }
}
