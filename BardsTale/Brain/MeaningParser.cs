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
            storyContext.WordsToUse = words;
            return storyContext;
        }

        private Character WhoIsTheMainCharacter(List<Word> words)
        {
            Character character = new Character();

            var animals = words.FindAll(w => w.Type == WordType.Animal);

            if (animals.Count > 0)
            {
                character.Type = animals[0].Value;
                words.Remove(animals[0]);
            }

            var adjectives = words.FindAll(w => w.Type == WordType.Adjective);

            if (adjectives.Count > 0)
            {
                character.Adjective = adjectives[0].Value;
                words.Remove(adjectives[0]);
            }

            var foods = words.FindAll(w => w.Type == WordType.Food);

            if (foods.Count > 0)
            {
                character.FavouriteFood = foods[0].Value;
                words.Remove(foods[0]);
            }

            var names = words.FindAll(w => w.Type == WordType.Name);

            if (names.Count > 0)
            {
                character.Name = names[0].Value;
                words.Remove(names[0]);
            }
            return character;
        }
    }
}
