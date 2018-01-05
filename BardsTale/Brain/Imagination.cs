using System;
using System.Linq;
using BardsTale.Model;

namespace BardsTale.Brain
{
    public class Imagination
    {
        private Random randomiser;
        private Memory memory;

        public Imagination(Memory memory){
            randomiser = new Random();
            this.memory = memory;
        }

        public string MakeUpBeginning(StoryContext context){
            return string.Format("Once upon a time there was a {0} {1} named {2}, who liked {3}", 
                                 context.MainCharacter.Adjective, 
                                 context.MainCharacter.Type, 
                                 context.MainCharacter.Name,
                                 WhatDidHeLike(context.MainCharacter));
        }

        public string GimmeAGoodEnding(StoryContext context){
            return string.Format("Um, yeah. And {0} lived happily ever after!",
                                 context.MainCharacter.Name);
        }

        public Character FillInTheMissingDetails(Character mainCharacter){
            if (string.IsNullOrEmpty(mainCharacter.Type))
                mainCharacter.Type = MakeUpSomeRandomCharacter();
            
            if (string.IsNullOrEmpty(mainCharacter.Name))
                mainCharacter.Name = MakeUpSomeRandomName();

            if (string.IsNullOrEmpty(mainCharacter.Adjective))
                mainCharacter.Adjective = MakeUpSomeAdjective();

            if (string.IsNullOrEmpty(mainCharacter.FavouriteFood))
                mainCharacter.FavouriteThing = "to move it move it";
            
            return mainCharacter;    
        }

        internal void FillInTheStoryContent(StoryContext story)
        {
            while (story.WordsToUse.Count > 0){
                story.Content.Add(MakeUpASentenceWithThisWord(story, story.WordsToUse.First()));
                story.WordsToUse.RemoveAt(0);
            }
        }

        public string MakeUpASentenceWithThisWord(StoryContext story, Word word) {
            if (word.Type == WordType.Animal)
                return string.Format("{0}'s best friend was a {1} {2}", story.MainCharacter.Name, MakeUpSomeAdjective(), word.Value);
            else if (word.Type == WordType.Name)
                return string.Format("When {0} finally got to {1}'s house, {2}", story.MainCharacter.Name, word.Value, MakeUpSomePlotTwist());
            else if (word.Type == WordType.Adjective)
                return string.Format("One day {0} met Mr. {1} the {2} head", story.MainCharacter.Name, MakeUpSomeRandomName(), word.Value);
            else if (word.Type == WordType.Food)
                return string.Format("Then all of the sudden, while {0} was busy eating some {1}, {2}!", story.MainCharacter.Name, word.Value, MakeUpSomePlotTwist());
            else if (word.Type == WordType.Noun)
                return string.Format("'Wow, that is a very nice {0}!', {1} said.", word.Value, story.MainCharacter.Name);
            else if (word.Type == WordType.Unknown)
                return string.Format("That never stopped {0} from asking questions, and the most important one was 'What the hell is {1}?'", story.MainCharacter.Name, word.Value);
            else if (word.Type == WordType.Verb)
                return string.Format("{0} sang: '{1} {1} {1}!!', because {0} was a little bit crazy.", story.MainCharacter.Name, word.Value);
            else
                return "La la la la la";
        }

        public string MakeUpSomePlotTwist() {
            return memory.PlotTwists.Value[randomiser.Next(memory.PlotTwists.Value.Count)];
        }

        public string MakeUpSomeRandomName()
        {
            return memory.Names.Value[randomiser.Next(memory.Names.Value.Count)];
        }

        public string MakeUpSomeRandomCharacter()
        {
            return memory.Animals.Value[randomiser.Next(memory.Animals.Value.Count)];
        }

        public string MakeUpSomeAdjective()
        {
            return memory.Adjectives.Value[randomiser.Next(memory.Adjectives.Value.Count)];
        }

        private string WhatDidHeLike(Character character)
        {
            if (!string.IsNullOrEmpty(character.FavouriteFood))
                return "to eat " + character.FavouriteFood;

            return character.FavouriteThing;
        }

    }
}
