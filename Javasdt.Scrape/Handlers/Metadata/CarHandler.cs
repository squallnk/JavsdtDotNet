using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Javasdt.Scrape.Handlers.Metadata
{
    public class CarHandler
    {
        public static int ExtractNumberFromCarSuf(string suf)
        {
            return int.Parse(Regex.Match(suf, @"(\d+)\w*").Groups[1].Value);
        }
    }
}
