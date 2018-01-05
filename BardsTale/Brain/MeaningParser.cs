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

            character.Type = FindWordOfType(words, WordType.Animal);
            character.Adjective = FindWordOfType(words, WordType.Adjective);
            character.FavouriteFood = FindWordOfType(words, WordType.Food);
            character.Name = FindWordOfType(words, WordType.Name);

            return character;
        }

        private string FindWordOfType(List<Word> words, WordType type){

            string wordThatMeans = "";
            var wordsOfType = words.FindAll(w => w.Type == type);

            if (wordsOfType.Count > 0)
            {
                wordThatMeans = wordsOfType[0].Value;
                words.Remove(wordsOfType[0]);
            }

            return wordThatMeans;
        }
    }
}
