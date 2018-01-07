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

        public string RandomiseSentenceWithWordType(WordType type) {
            var sentences = memory.PlotLines.Value.Where(s => s.Contains("[" + type.ToString() +"]"));
            return sentences.ElementAt(randomiser.Next(sentences.Count()));
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
