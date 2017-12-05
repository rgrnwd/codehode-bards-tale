using System;
using BardsTale.Model;

namespace BardsTale.Brain
{
    public class WordProcessor
    {
        private WordDictionary dictionary;

        public WordProcessor(String projectDirectory)
        {
            dictionary = new WordDictionary(projectDirectory);
        }

        public Word Process(String text){
            return dictionary.Lookup(text);
        }

    }
}
