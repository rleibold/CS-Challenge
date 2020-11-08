using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Services;
using Newtonsoft.Json;


namespace ConsoleApp1
{
    class Program
    {
        private const string chuckNorrisApiBaseUrl = "https://api.chucknorris.io";
        private const string namePrivServApiBaseUrl = "https://names.privserv.com/api/";
        
        // TODO - refactor to remove all static variables
        static string[] results = new string[50];
        static char key;
        static Tuple<string, string> names;
        static ConsolePrinter printer = new ConsolePrinter();
        private static HttpClient httpClient = new HttpClient();
        private static JokeGeneratorService jokeGeneratorService = new JokeGeneratorService(httpClient, chuckNorrisApiBaseUrl, namePrivServApiBaseUrl);

        static void Main(string[] args)
        {
            // Refactor this method be more modular and easier to unit test
            while (true)
            {
                string category = null;
                int numberOfJokes = 1;
                
                PrintResult("Press Spacebar to get instructions.");
                GetEnteredKey(Console.ReadKey());
                if (key.Equals(' '))
                {
                    PrintResult("Press c to get categories");
                    PrintResult("Press r to get random jokes");
                    PrintResult("Press q to Quit.");
                }
                else if (key.Equals('q'))
                {
                    break;
                }
                else if (key.Equals('c'))
                {
                    PrintResult(jokeGeneratorService.GetCategoriesAsString());
                }
                else if (key.Equals('r'))
                {
                    printer.Value("Want to use a random name? y/n").ToString();
                    GetEnteredKey(Console.ReadKey());
                    if (key.Equals('y'))
                        GetNames();
                    printer.Value("Want to specify a category? y/n").ToString();
                    GetEnteredKey(Console.ReadKey());
                    if (key.Equals('y'))
                    {
                        printer.Value("Enter a category;").ToString();
                        category = Console.ReadLine();
                    }
                    
                    printer.Value("How many jokes do you want? (1-9)").ToString();
                    numberOfJokes = Int32.Parse(Console.ReadLine());
                    GetRandomJokes(category, numberOfJokes);
                }
                names = null;
            }

            PrintResult("Goodbye...");
        }

        private static void PrintResult(string output)
        {
            Console.WriteLine(output);
        }
        
        [Obsolete("PrintResults() is deprecated.  Please use PrintResult() method.")]
        private static void PrintResults()
        {
            printer.Value("[" + string.Join(",", results) + "]").ToString();
        }

        
        private static void GetEnteredKey(ConsoleKeyInfo consoleKeyInfo)
        {
            // TODO - refactor to remove use of ConsoleKeyInfo as does not support all charaters and
            // adds unnecessary complexity
            PrintResult(""); // Add a cariage return after user input
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.C:
                    key = 'c';
                    break;
                case ConsoleKey.D0:
                    key = '0';
                    break;
                case ConsoleKey.D1:
                    key = '1';
                    break;
                case ConsoleKey.D2:
                    key = '2';
                    break;
                case ConsoleKey.D3:
                    key = '3';
                    break;
                case ConsoleKey.D4:
                    key = '4';
                    break;
                case ConsoleKey.D5:
                    key = '5';
                    break;
                case ConsoleKey.D6:
                    key = '6';
                    break;
                case ConsoleKey.D7:
                    key = '7';
                    break;
                case ConsoleKey.D8:
                    key = '8';
                    break;
                case ConsoleKey.D9:
                    key = '9';
                    break;
                case ConsoleKey.R:
                    key = 'r';
                    break;
                case ConsoleKey.Y:
                    key = 'y';
                    break;
                case ConsoleKey.N:
                    key = 'n';
                    break;
                case ConsoleKey.Spacebar:
                    key = ' ';
                    break;
                case ConsoleKey.Q:
                    key = 'q';
                    break;
            }
        }
        
        private static void GetRandomJokes(string category, int number)
        {
            for (int i = 0; i < number; i++)
            {
                PrintResult(jokeGeneratorService.GetRandomJoke(names?.Item1, names?.Item2, category));    
            }
        }

        [Obsolete("getCategories() is obsolete.  Use JokeGeneratorService.GetCategoriesAsString()")]
        private static void getCategories()
        {
            new JsonFeed("https://api.chucknorris.io", 0);
            results = JsonFeed.GetCategories();
        }
        
        private static void GetNames()
        {
            var namePrivServNameDto = jokeGeneratorService.GetRandomName();
            names = Tuple.Create(namePrivServNameDto.name, namePrivServNameDto.surname); // TODO - This shouldn't be using static variable names like this
        }
    }
}
