using System;
using BardsTale.Brain;
using BardsTale.Model.Exceptions;

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
            Console.WriteLine("OK let me think...");

            try
            {
                MeaningParser meaningParser = new MeaningParser(words);
                string subjectOfTheStory = meaningParser.FindSubjectOfTheStory();
                Console.WriteLine("Well, I think I'm going to tell you a story about " + subjectOfTheStory);
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
