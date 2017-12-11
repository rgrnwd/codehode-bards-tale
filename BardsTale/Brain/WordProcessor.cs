using System;
using System.Collections.Generic;
using BardsTale.Model;

namespace BardsTale.Brain
{
    public class WordProcessor
    {
        private Memory dictionary;

        public WordProcessor(String projectDirectory)
        {
            dictionary = new Memory(projectDirectory);
        }

        public Word Process(String word){
            return dictionary.Lookup(word);
        }

        public List<Word> GetWordsFromSentence(String sentence)
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
