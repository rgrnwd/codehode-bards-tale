using System;
using System.Collections.Generic;

namespace BardsTale.Model
{
    public class StoryContext
    {
        public string Title { get; set; }
        public Character MainCharacter { get; set; }
        public List<Word> WordsToUse { get; set; }
        public List<string> Content { get; set; }

        public StoryContext()
        {
            this.Content = new List<string>();
        }
    }
}
