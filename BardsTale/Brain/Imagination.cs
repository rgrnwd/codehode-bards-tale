using System;
using System.Collections.Generic;
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
                                 context.MainCharacter.FavouriteFood ?? context.MainCharacter.FavouriteThing);
        }

        public Character FillInTheMissingDetails(Character mainCharacter){
            mainCharacter.Name = MakeUpSomeRandomName();

            if (string.IsNullOrEmpty(mainCharacter.Adjective))
                mainCharacter.Adjective = MakeUpSomeAdjective();

            if (string.IsNullOrEmpty(mainCharacter.FavouriteFood))
                mainCharacter.FavouriteThing = "to move it move it";
            
            return mainCharacter;    
        }

        public string MakeUpSomeRandomName(){
            var someNamesIKnow = new List<string>() { "Bob", "George", "Bill", "Charlie", "Lucy", "Alice", "Sarah", "Minnie", "Fluffy", "TinkleWinkle" };

            return someNamesIKnow[randomiser.Next(someNamesIKnow.Count)];
        }

        public string MakeUpSomeAdjective()
        {
            return memory.Adjectives.Value[randomiser.Next(memory.Adjectives.Value.Count)];
        }
    }
}
