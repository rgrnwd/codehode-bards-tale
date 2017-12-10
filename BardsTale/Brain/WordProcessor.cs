using System;
using System.Collections.Generic;
using BardsTale.Model;

namespace BardsTale.Brain
{
    public class WordProcessor
    {
        private Dictionary dictionary;

        public WordProcessor(String projectDirectory)
        {
            dictionary = new Dictionary(projectDirectory);
        }

        public Word Process(String word){
            return dictionary.Lookup(word);
        }

        public List<Word> ProcessSentence(String sentence)
        {
            List<Word> words = new List<Word>();
            string[] particles = sentence.Split(' ', ',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var particle in particles)
            {
                words.Add(dictionary.Lookup(particle));
            }

            return words;
        }
    }
}
