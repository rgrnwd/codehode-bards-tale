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
        private const string NAMES_DICTIONARY = "Names.txt";

        private Lazy<List<String>> animals;
        private Lazy<List<String>> foods;
        private Lazy<List<String>> verbs;
        private Lazy<List<String>> nouns;
        private Lazy<List<String>> adjectives;
        private Lazy<List<String>> names;

        public Lazy<List<string>> Adjectives { get => adjectives; set => adjectives = value; }
        public Lazy<List<string>> Animals { get => animals; set => animals = value; }
        public Lazy<List<string>> Foods { get => foods; set => foods = value; }
        public Lazy<List<string>> Verbs { get => verbs; set => verbs = value; }
        public Lazy<List<string>> Nouns { get => nouns; set => nouns = value; }
        public Lazy<List<string>> Names { get => names; set => names = value; }

        public Memory(string projectDirectory)
        {
            var resourcesFolder = Path.Combine(projectDirectory, "Resources/Words");
            Animals = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(resourcesFolder, ANIMALS_DICTIONARY)));
            Foods = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(resourcesFolder, FOODS_DICTIONARY)));
            Adjectives = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(resourcesFolder, ADJECTIVES_DICTIONARY)));
            Verbs = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(resourcesFolder, VERBS_DICTIONARY)));
            Nouns = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(resourcesFolder, NOUNS_DICTIONARY)));
            Names = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(resourcesFolder, NAMES_DICTIONARY)));
        }

        public Word Lookup(String word)
        {
            if (Foods.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Food);
            else if (Animals.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Animal);
            else if (Verbs.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Verb);
            else if (Nouns.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Noun);
            else if (Adjectives.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Adjective);
            else if (Names.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Name);

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
