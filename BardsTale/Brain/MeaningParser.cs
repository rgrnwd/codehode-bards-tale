using System;
using System.Collections.Generic;
using BardsTale.Model;
using BardsTale.Model.Exceptions;

namespace BardsTale.Brain
{
    public class MeaningParser
    {
        private List<Word> words;

        public MeaningParser(List<Word> words)
        {
            this.words = words;
        }

        public string FindSubjectOfTheStory(){
            
            throw new InvalidInputException();
        }
    }
}
