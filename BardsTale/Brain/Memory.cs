using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BardsTale.Model;
using BardsTale.Model.Exceptions;

namespace BardsTale.Brain
{
    public class Memory
    {
        private const string VERBS_DICTIONARY = "Verbs.txt";
        private const string NOUNS_DICTIONARY = "Nouns.txt";
        private const string ADJECTIVES_DICTIONARY = "Adjectives.txt";

        private const string ANIMALS_DICTIONARY = "Animals.txt";
        private const string FOODS_DICTIONARY = "Foods.txt";

        private Lazy<List<String>> animals;
        private Lazy<List<String>> foods;
        private Lazy<List<String>> verbs;
        private Lazy<List<String>> nouns;
        private Lazy<List<String>> adjectives;

        public Memory(string projectDirectory)
        {
            var resourcesFolder = Path.Combine(projectDirectory, "Resources/Words");
            animals = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(resourcesFolder, ANIMALS_DICTIONARY)));
            foods = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(resourcesFolder, FOODS_DICTIONARY)));
            adjectives = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(resourcesFolder, ADJECTIVES_DICTIONARY)));
            verbs = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(resourcesFolder, VERBS_DICTIONARY)));
            nouns = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(resourcesFolder, NOUNS_DICTIONARY)));
        }

        public Word Lookup(String word)
        {
            if (foods.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Food);
            else if (animals.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Animal);
            else if (verbs.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Verb);
            else if (nouns.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Noun);
            else if (adjectives.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
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
