using System;
using BardsTale.Brain;

namespace BardsTale
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let me tell you a tale!");
            Console.WriteLine("First of all, please give me a theme... ");
            Console.WriteLine("(you can enter up to five words and I will do my best to tell you a tale relevant to those words)");
            string theme = Console.ReadLine();
            var words = new WordProcessor(GetMainProjectDirectory()).ProcessSentence(theme);
            Console.WriteLine("Just to clarify, I think you want me to tell you a story about...");

            foreach (var word in words)
            {
                Console.Write(string.Format("{0} ({1}) ",word.Value, word.Type));
            }
        }

        public static String GetMainProjectDirectory()
        {
            var solutionFolder = AppContext.BaseDirectory.Substring(0,
              AppContext.BaseDirectory.IndexOf("bin", StringComparison.OrdinalIgnoreCase));

            return solutionFolder;
        }
    }
}
