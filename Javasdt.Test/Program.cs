using System;
using Javasdt.Collector;

namespace Javasdt.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = DbHandler.GetHtml("https://www.n53i.com/");
            Console.WriteLine(a);
        }
    }
}
