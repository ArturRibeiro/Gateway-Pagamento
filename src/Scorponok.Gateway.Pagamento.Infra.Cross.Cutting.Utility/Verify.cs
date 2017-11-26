using System;

namespace Scorponok.Gateway.Pagamento.Infra.Cross.Cutting.Utility
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
