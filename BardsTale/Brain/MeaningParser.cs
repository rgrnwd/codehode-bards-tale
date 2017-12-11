using System;
using System.Collections.Generic;
using System.Linq;
using BardsTale.Model;
using BardsTale.Model.Exceptions;

namespace BardsTale.Brain
{
    public class MeaningParser
    {
        public StoryContext WhatDoTheyWantAStoryAbout(List<Word> words){

            if (words.Count == 0) throw new InvalidInputException();

            StoryContext storyContext = new StoryContext();
            storyContext.MainCharacter = WhoIsTheMainCharacter(words);

            return storyContext;
        }

        private Character WhoIsTheMainCharacter(List<Word> words)
        {
            Character character = new Character();

            var animals = words.FindAll(w => w.Type == WordType.Animal);

            if (animals.Count > 0)
            {
                character.Type = animals[0].Value;
            }

            var adjectives = words.FindAll(w => w.Type == WordType.Adjective);

            if (adjectives.Count > 0)
            {
                character.Adjective = adjectives[0].Value;
            }


            var nouns = words.FindAll(w => w.Type == WordType.Food);

            if (nouns.Count > 0)
            {
                character.Likes = nouns[0].Value;
            }

            return character;
        }
    }
}
