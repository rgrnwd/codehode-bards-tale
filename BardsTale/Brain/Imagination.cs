using System;
using System.Collections.Generic;

namespace BardsTale.Brain
{
    public class Imagination
    {
        private Random randomiser;

        public Imagination(){
            randomiser = new Random();
        }
        public string MakeUpSomeRandomName(){
            var someNamesIKnow = new List<string>() { "Bob", "George", "Bill", "Charlie", "Lucy", "Alice", "Sarah", "Minnie", "Fluffy", "TinkleWinkle" };

            return someNamesIKnow[randomiser.Next(someNamesIKnow.Count)];
        }
    }
}
