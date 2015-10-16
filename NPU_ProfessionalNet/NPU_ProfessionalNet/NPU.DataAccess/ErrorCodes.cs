using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPU.DataAccess
{
    internal static class ErrorCodes
    {
        public const byte ValidationError = 1;
        public const byte ConcurrencyViolationError = 2;
        public const int SqlUserRaisedError = 50000;
    }
}
