using System;
using System.Threading;
using BardsTale.Brain;
using BardsTale.Model.Exceptions;

namespace BardsTale
{
    class Program
    {
        static Bard bard;

        static void Main(string[] args)
        {
            bard = new Bard(GetMainProjectDirectory());

            TellThemWhatWereAllAbout();
            string theme = Console.ReadLine();

            var words = new WordProcessor(GetMainProjectDirectory()).GetWordsFromSentence(theme);

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

        private static void TellThemWhatWereAllAbout()
        {
            Console.WriteLine("Let me tell you a tale!");
            Console.WriteLine("First of all, please give me a theme... ");
            Console.WriteLine("(you can enter up to five words and I will do my best to tell you a tale relevant to those words)");
        }

        public static String GetMainProjectDirectory()
        {
            var solutionFolder = AppContext.BaseDirectory.Substring(0,
              AppContext.BaseDirectory.IndexOf("bin", StringComparison.OrdinalIgnoreCase));

            return solutionFolder;
        }
    }
}
