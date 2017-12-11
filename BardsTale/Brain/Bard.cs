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

        public Bard()
        {
            imagination = new Imagination();
        }

        public StoryContext TellStory(List<Word> keywords){
            meaningParser = new MeaningParser();

            story = meaningParser.WhatDoTheyWantAStoryAbout(keywords);
            story.MainCharacter.Name = imagination.MakeUpSomeRandomName();
            story.Title = string.Format("A {0} {1} named {2}", story.MainCharacter.Adjective, story.MainCharacter.Type, story.MainCharacter.Name);
            story.Content.Add("this is the first line of content");
            story.Content.Add("this is the second line of content");
            story.Content.Add("this is the third line of content");
            story.Content.Add("this is the fourth line of content");
            story.Content.Add("this is the fifth line of content");
            story.Content.Add("this is the sixth line of content");
            return story;
        }
    }
}
