using System;
using System.Collections.Generic;
using BardsTale.Model;

namespace BardsTale.Brain
{
    public class WordProcessor
    {
        private Memory memory;

        public Memory Memory { get => memory; set => memory = value; }

        public WordProcessor(String projectDirectory)
        {
            Memory = new Memory(projectDirectory);
        }

        public Word Process(String word)
        {
            return Memory.Lookup(word);
        }

        public List<Word> GetWordsFromSentence(String sentence)
        {
            List<Word> words = new List<Word>();
            string[] particles = sentence.Split(' ', ',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var particle in particles)
            {
                words.Add(Memory.Lookup(particle));
            }

            return words;
        }
    }
}
