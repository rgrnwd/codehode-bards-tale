using System;
using System.Collections.Generic;
using BardsTale.Model;

namespace BardsTale.Brain
{
    public class Imagination
    {
        private Random randomiser;

        public Imagination(){
            randomiser = new Random();
        }

        public string MakeUpBeginning(StoryContext context){
            return string.Format("Once upon a time there was a {0} {1} named {2}, who liked {3}", 
                                 context.MainCharacter.Adjective, 
                                 context.MainCharacter.Type, 
                                 context.MainCharacter.Name,
                                 context.MainCharacter.Likes);
        }

        public string MakeUpSomeRandomName(){
            var someNamesIKnow = new List<string>() { "Bob", "George", "Bill", "Charlie", "Lucy", "Alice", "Sarah", "Minnie", "Fluffy", "TinkleWinkle" };

            return someNamesIKnow[randomiser.Next(someNamesIKnow.Count)];
        }
    }
}
