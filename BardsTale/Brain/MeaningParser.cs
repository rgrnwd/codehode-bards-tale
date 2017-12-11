using System;
using System.Collections.Generic;
using BardsTale.Model;
using BardsTale.Model.Exceptions;

namespace BardsTale.Brain
{
    public class MeaningParser
    {
        public StoryContext WhatDoTheyWantAStoryAbout(List<Word> words){

            if (words.Count == 0) throw new InvalidInputException();

            StoryContext storyContext = new StoryContext();

            var animals = words.FindAll(w => w.Type == WordType.Animal);

            if (animals.Count > 0){
                storyContext.MainCharacter = new Character(animals[0].Value);
            }

            return storyContext;
        }
    }
}
