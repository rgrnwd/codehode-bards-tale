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
        private const string COLORS_DICTIONARY = "Colors.txt";
        private const string LOCATIONS_DICTIONARY = "Locations.txt";
        private const string THINGS_DICTIONARY = "Things.txt";
        private const string ANIMALS_DICTIONARY = "Animals.txt";
        private const string FOODS_DICTIONARY = "Foods.txt";
        private const string NAMES_DICTIONARY = "Names.txt";

        private const string PLOT_LINES = "Plot.txt";
        private const string PLOT_TWISTS = "PlotTwists.txt";

        private Lazy<List<String>> animals;
        private Lazy<List<String>> foods;
        private Lazy<List<String>> verbs;
        private Lazy<List<String>> nouns;
        private Lazy<List<String>> adjectives;
        private Lazy<List<String>> names;
        private Lazy<List<String>> colors;
        private Lazy<List<String>> locations;
        private Lazy<List<String>> things;
        private Lazy<List<String>> plotLines;
        private Lazy<List<String>> plotTwists;

        public Lazy<List<string>> Adjectives { get => adjectives; set => adjectives = value; }
        public Lazy<List<string>> Animals { get => animals; set => animals = value; }
        public Lazy<List<string>> Foods { get => foods; set => foods = value; }
        public Lazy<List<string>> Verbs { get => verbs; set => verbs = value; }
        public Lazy<List<string>> Nouns { get => nouns; set => nouns = value; }
        public Lazy<List<string>> Names { get => names; set => names = value; }
        public Lazy<List<string>> Colors { get => colors; set => colors = value; }
        public Lazy<List<string>> Locations { get => locations; set => locations = value; }
        public Lazy<List<string>> Things { get => things; set => things = value; }
        public Lazy<List<string>> PlotLines { get => plotLines; set => plotLines = value; }
        public Lazy<List<string>> PlotTwists { get => plotTwists; set => plotTwists = value; }

        public Memory(string projectDirectory)
        {
            var knownWords = Path.Combine(projectDirectory, "Resources/Words");
            Animals = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(knownWords, ANIMALS_DICTIONARY)));
            Foods = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(knownWords, FOODS_DICTIONARY)));
            Adjectives = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(knownWords, ADJECTIVES_DICTIONARY)));
            Verbs = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(knownWords, VERBS_DICTIONARY)));
            Nouns = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(knownWords, NOUNS_DICTIONARY)));
            Names = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(knownWords, NAMES_DICTIONARY)));
            Colors = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(knownWords, COLORS_DICTIONARY)));
            Locations = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(knownWords, LOCATIONS_DICTIONARY)));
            Things = new Lazy<List<string>>(() => LoadWordsFromDictionary(Path.Combine(knownWords, THINGS_DICTIONARY)));

            var knownSentences = Path.Combine(projectDirectory, "Resources/Sentences");
            PlotLines = new Lazy<List<string>>(() => LoadSentencesFromFile(Path.Combine(knownSentences, PLOT_LINES)));
            PlotTwists = new Lazy<List<string>>(() => LoadSentencesFromFile(Path.Combine(knownSentences, PLOT_TWISTS)));
        }

        public Word Lookup(String word)
        {
            if (Foods.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Food);
            else if (Animals.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Animal);
            else if (Colors.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Color);
            else if (Locations.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Location);
            else if (Things.Value.Any(s => s.Equals(word, StringComparison.OrdinalIgnoreCase)))
                return new Word(word, WordType.Thing);
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
        private List<String> LoadSentencesFromFile(string file)
        {
            List<String> sentences = null;

            try
            {
                sentences = File.ReadAllLines(file).ToList();
            }
            catch (IOException)
            {
                throw new DictionaryNotFoundException(file);
            }

            return sentences;
        }
    }
}
