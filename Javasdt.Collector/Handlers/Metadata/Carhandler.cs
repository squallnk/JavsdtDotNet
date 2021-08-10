using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Javasdt.Collector.Handlers.Metadata
{
    public class CarHandler
    {
        public static string ExtractNumberFromCarSuf(string suf)
        {
            return Regex.Match(suf, @"(\d+)\w*").Groups[1].Value;
        }
    }
}
