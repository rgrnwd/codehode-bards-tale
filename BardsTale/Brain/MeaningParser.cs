using System;
using System.Collections.Generic;
using BardsTale.Model;
using BardsTale.Model.Exceptions;

namespace BardsTale.Brain
{
    public class MeaningParser
    {
        private List<Word> words;
        private Imagination imagination;

        public MeaningParser(List<Word> words)
        {
            imagination = new Imagination();
            this.words = words;
        }

        public string FindSubjectOfTheStory(){
            var animals = words.FindAll(w => w.Type == WordType.Animal);

            if (animals.Count > 0)
                return String.Format("A {0} named {1}", animals[0].Value, imagination.MakeUpSomeRandomName());
            
            throw new InvalidInputException();
        }
    }
}
