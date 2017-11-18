using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Core.Events
{

    /// <summary>
    ///     https://msdn.microsoft.com/pt-br/library/dd799517(v=vs.110).aspx
    ///     Porque estou utilizando "in T"?  posso passar um command ou uma message.... tudo e mensagem
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHandler<in T> where  T : Message
    {
        void Handle(T message);
    }
}
