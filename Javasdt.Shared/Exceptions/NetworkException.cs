﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javasdt.Shared.Exceptions
{
    public class NetworkException :Exception
    {
        public NetworkException()
        {
        }

        public NetworkException(string message)
            : base(message)
        {
        }

        public NetworkException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
