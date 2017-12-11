using System;
using System.Threading;
using BardsTale.Brain;
using BardsTale.Model.Exceptions;

namespace BardsTale
{
    class Program
    {
        static Bard bard = new Bard();

        static void Main(string[] args)
        {
            Console.WriteLine("Let me tell you a tale!");
            Console.WriteLine("First of all, please give me a theme... ");
            Console.WriteLine("(you can enter up to five words and I will do my best to tell you a tale relevant to those words)");
            string theme = Console.ReadLine();
            var words = new WordProcessor(GetMainProjectDirectory()).GetWordsFromSentence(theme);
            Console.WriteLine("OK let me think...");

            try
            {
                var story = bard.TellStory(words);
                Console.WriteLine("Well, here we go... are you ready? here is my story!");
                Console.WriteLine(story.Title);
                Console.WriteLine("==========================================================");

                foreach (var line in story.Content)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine(line);
                }
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
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
