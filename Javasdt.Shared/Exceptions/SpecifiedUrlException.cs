using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javasdt.Shared.Exceptions
{
    public class SpecifiedUrlException : Exception
    {
        public SpecifiedUrlException()
        {
        }

        public SpecifiedUrlException(string message)
            : base(message)
        {
        }

        public SpecifiedUrlException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
