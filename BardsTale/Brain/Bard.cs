using System;
using System.Collections.Generic;
using System.Linq;
using BardsTale.Model;

namespace BardsTale.Brain
{
    public class Bard
    {
        private StoryContext story;
        private Imagination imagination;
        private MeaningParser meaningParser;
        private Memory memory;
        private const int MIN_STORY_LENGTH = 8;

        public StoryContext Story { get => story; set => story = value; }

        public Bard(string projectDirectory)
        {
            memory = new Memory(projectDirectory);
            imagination = new Imagination(memory);
        }

        public StoryContext TellStory(List<Word> keywords)
        {
            GetStoryContext(keywords);
            ComposeStory();
            return story;
        }

        public void GetStoryContext(List<Word> keywords)
        {
            meaningParser = new MeaningParser();

            story = meaningParser.WhatDoTheyWantAStoryAbout(keywords);
            story.MainCharacter = imagination.FillInTheMissingDetails(story.MainCharacter);
            story.Title = GetStoryTitle();
        }

        private void ComposeStory()
        {
            story.Content.Add(imagination.MakeUpBeginning(story));

            while (story.WordsToUse.Count > 0)
            {
                Word word = story.WordsToUse.First();
                String sentence = imagination.RandomiseSentenceWithWordType(word.Type);
                story.Content.Add(FormatContextIntoSentence(sentence, word));
                story.WordsToUse.RemoveAt(0);
            }

            if (story.Content.Count() < MIN_STORY_LENGTH){
                string location = "beach";
                string thingFound = "seashells";
                story.Content.Add(string.Format("One day {0}, which as we know was really {1}, decided to go on a trip to the {2}", story.MainCharacter.Name, story.MainCharacter.Adjective, location));
                story.Content.Add(string.Format("At the {0} there were lots of {1}, which besides {2} were the best thing in the world!!", location, thingFound, story.MainCharacter.FavouriteFood));
                story.Content.Add(string.Format("So {0} sat and played with the {1} for a while, but suddenly {2}", story.MainCharacter.Name, thingFound, imagination.MakeUpSomePlotTwist()));
                story.Content.Add("But of course, nothing really came out of that at the end.");
            }

            story.Content.Add(imagination.GimmeAGoodEnding(story));
        }

        public string FormatContextIntoSentence(string sentence, Word word)
        {
            sentence = sentence.Replace("[MAINCHAR]", story.MainCharacter.Name);
            sentence = sentence.Replace("[Noun]", word.Type == WordType.Noun ? word.Value : "coin");
            sentence = sentence.Replace("[Food]", word.Type == WordType.Food ? word.Value : "banana");
            sentence = sentence.Replace("[Animal]", word.Type == WordType.Animal ? word.Value : imagination.MakeUpSomeRandomCharacter());
            sentence = sentence.Replace("[Adjective]", word.Type == WordType.Adjective ? word.Value : "chubby");
            sentence = sentence.Replace("[Verb]", word.Type == WordType.Verb ? word.Value : "jump");
            sentence = sentence.Replace("[Color]", word.Type == WordType.Color ? word.Value : "red");
            sentence = sentence.Replace("[Location]", word.Type == WordType.Location ? word.Value : "beach");
            sentence = sentence.Replace("[Thing]", word.Type == WordType.Thing ? word.Value : "stones");
            sentence = sentence.Replace("[Unknown]", word.Value);
            sentence = sentence.Replace("[Name]", imagination.MakeUpSomeRandomName());
            sentence = sentence.Replace("[PLOTTWIST]", imagination.MakeUpSomePlotTwist());
            return sentence;
        }

        private string GetStoryTitle()
        {
            string title = string.Format("A {0} {1} named {2}", story.MainCharacter.Adjective, story.MainCharacter.Type, story.MainCharacter.Name);

            if (!string.IsNullOrEmpty(story.MainCharacter.FavouriteFood))
                title += " who likes " + story.MainCharacter.FavouriteFood;

            return title;
        }
    }
}
