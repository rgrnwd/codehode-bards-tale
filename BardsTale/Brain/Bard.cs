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

        public Bard(string projectDirectory)
        {
            memory = new Memory(projectDirectory);
            imagination = new Imagination(memory);
        }

        public StoryContext TellStory(List<Word> keywords)
        {
            meaningParser = new MeaningParser();

            story = meaningParser.WhatDoTheyWantAStoryAbout(keywords);
            story.MainCharacter = imagination.FillInTheMissingDetails(story.MainCharacter);
            story.Title = GetStoryTitle();
            ComposeStory();
            return story;
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

            story.Content.Add(imagination.GimmeAGoodEnding(story));
        }

        private string FormatContextIntoSentence(string sentence, Word word)
        {
            sentence = sentence.Replace("[MAINCHAR]", story.MainCharacter.Name);
            sentence = sentence.Replace("[NOUN]", word.Type == WordType.Noun ? word.Value : "coin");
            sentence = sentence.Replace("[FOOD]", word.Type == WordType.Food ? word.Value : "banana");
            sentence = sentence.Replace("[ANIMAL]", word.Type == WordType.Animal ? word.Value : imagination.MakeUpSomeRandomCharacter());
            sentence = sentence.Replace("[ADJ]", word.Type == WordType.Adjective ? word.Value : "chubby");
            sentence = sentence.Replace("[VERB]", word.Type == WordType.Verb ? word.Value : "jump");
            sentence = sentence.Replace("[UNKNOWN]", word.Value);
            sentence = sentence.Replace("[NAME]", imagination.MakeUpSomeRandomName());
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
