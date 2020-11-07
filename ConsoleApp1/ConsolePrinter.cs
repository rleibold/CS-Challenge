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
        public static object PrintValue; // TODO Should not be public and static, and add getter and setter methods

        public ConsolePrinter Value(string value) // TODO Refactor this method to be immutable instance
        {
            PrintValue = value;
            return this;
        }

        public override string ToString()
        {
            Console.WriteLine(PrintValue);
            return null;
        }
    }
}
