using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javasdt.Shared.Exceptions
{
    public class WebNotFoundException : Exception
    {
        public WebNotFoundException()
        {
        }

        public WebNotFoundException(string message)
            : base(message)
        {
        }

        public WebNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
