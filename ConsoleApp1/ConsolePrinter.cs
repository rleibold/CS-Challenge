using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class ConsolePrinter
    {
        public static object PrintValue; // TODO Should not be public and static, not thread safe

        [Obsolete("Value() method is deprecated.  Use Console.WriteLine() instead.")]
        public ConsolePrinter Value(string value) // TODO Refactor this method to be immutable instance
        {
            PrintValue = value;
            return this;
        }
        
        [Obsolete("Value() method is deprecated.  Use Console.WriteLine() instead.")]
        public override string ToString()
        {
            Console.WriteLine(PrintValue);
            return null;
        }
    }
}
