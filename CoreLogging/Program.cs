using Serilog;
using Serilog.Core;
using System;

namespace CoreLogging
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            {
                Log.Logger = new LoggerConfiguration()
                                .WriteTo.Console()
                                .WriteTo.File(@"C:\Users\vlogg\source\Logging\CoreLogging\LogFile.txt")

                                //create logger
                                .CreateLogger();

                for (int x = 0; x < 2; x++)
                {
                    Log.Information($"Hello, Serilog! {x}");
                    Log.Warning($"Goodbye, Serilog. {x}");
                    Log.Information($"Time to add 2 numbers:" +
                        $"{DateTime.Now.ToUniversalTime()}  {x}");
                    Log.Verbose($"Verbose log message: {x}");
                }

                Log.CloseAndFlush();
                Console.WriteLine("-----------------------");
                ReadFromFile();
                Console.ReadLine();

            }
        }

        //outside main
        //ReadFromFile function: 
        private static void ReadFromFile()
        {
            //load file as string array
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\vlogg\source\Logging\CoreLogging\LogFile.txt");

            //print to console
            foreach (string line in lines)
            {
                //use a tab to indent each line of the file
                Console.WriteLine("\t" + line);
            }
        }
    }
}
