using System;
using System.Collections.Generic;
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

            imagination.FillInTheStoryContent(story);

            story.Content.Add(imagination.GimmeAGoodEnding(story));
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
