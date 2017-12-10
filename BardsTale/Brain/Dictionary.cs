using System;
using System.Collections.Generic;
using System.IO;
using BardsTale.Model;
using BardsTale.Model.Exceptions;

namespace BardsTale.Brain
{
    public class WordDictionary
    {
        private const string VERBS_DICTIONARY = "Verbs.txt";
        private const string NOUNS_DICTIONARY = "Nouns.txt";
        private const string ADJECTIVES_DICTIONARY = "Adjectives.txt";

        private Lazy<List<String>> verbs;
        private Lazy<List<String>> nouns;
        private Lazy<List<String>> adjectives;

        public WordDictionary(string projectDirectory)
        {
            var resourcesFolder = Path.Combine(projectDirectory, "Resources");
            verbs = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(resourcesFolder, VERBS_DICTIONARY)));
            nouns = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(resourcesFolder, NOUNS_DICTIONARY)));
            adjectives = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(resourcesFolder, ADJECTIVES_DICTIONARY)));
        }

        public Word Lookup(String word)
        {
            if (verbs.Value.Contains(word))
                return new Word(word, WordType.Verb);
            else if (nouns.Value.Contains(word))
                return new Word(word, WordType.Noun);
            else if (adjectives.Value.Contains(word))
                return new Word(word, WordType.Adjective);
            
            return new Word(word, WordType.Unknown);
        }

        private List<String> LoadWordsFromDictionary(string dictionary)
        {
            List<String> words = null;

            try
            {
                words = new List<String>(File.ReadAllLines(dictionary));
            }
            catch (IOException)
            {
                throw new DictionaryNotFoundException(dictionary);
            }

            return words;
        }
    }
}
