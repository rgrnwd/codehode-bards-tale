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
            story.Content.Add("this is the second line of content");
            story.Content.Add("this is the third line of content");
            story.Content.Add("this is the fourth line of content");
            story.Content.Add("this is the fifth line of content");
            story.Content.Add("this is the sixth line of content");
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
