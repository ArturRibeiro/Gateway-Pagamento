using System;
using System.Collections.Generic;
using System.Text;

namespace Scorponok.Gateway.Pagamento.Domain.Core.Commands
{
    public class CommandResult
    {
        public static CommandResult Ok = new CommandResult(true);

        public static CommandResult Fail = new CommandResult(false);

        public CommandResult(bool success = false)
        {
            this.Success = success;
        }

        public bool Success
        {
            get;
            private set;
        }
    }
}
