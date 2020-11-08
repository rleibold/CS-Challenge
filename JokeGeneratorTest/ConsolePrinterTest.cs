using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JokeGeneratorTest
{
    [TestClass]
    public class ConsolePrinterTest1
    {
        private const string printValueTestValue = "Test123";    
        
        [TestMethod]
        public void TestSetAndReturnConsolePrinter()
        {
            var consolePrinter = new ConsolePrinter();
            consolePrinter.Value(printValueTestValue);

            Assert.AreEqual(printValueTestValue, ConsolePrinter.PrintValue);
        }
    }
}