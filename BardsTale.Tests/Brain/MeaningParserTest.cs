using System;
using System.Collections.Generic;

using Xunit;

using BardsTale.Brain;
using BardsTale.Model;
using BardsTale.Model.Exceptions;

namespace BardsTale.Tests.Brain
{
    public class MeaningParserTest
    {
        MeaningParser meaningParser = new MeaningParser();

        [Fact]
        public void WhatDoTheyWantAStoryAbout_EmptyListOfWords_ThrowError()
        {
            Exception ex = Assert.Throws<InvalidInputException>(() =>  meaningParser.WhatDoTheyWantAStoryAbout(new List<Word>()));
        }

        [Fact]
        public void WhatDoTheyWantAStoryAbout_WordsContainsAnimal_ReturnsContextWithCharacter()
        {
            var result = meaningParser.WhatDoTheyWantAStoryAbout(new List<Word>() { new Word("Zebra", WordType.Animal) });

            Assert.Equal("Zebra", result.MainCharacter.Type);
        }

        [Fact]
        public void WhatDoTheyWantAStoryAbout_WordsContainsAnimalAndAdjective_ReturnsContextWithCharacterInformation()
        {
            var words = new List<Word>() { new Word("Zebra", WordType.Animal), new Word("fat", WordType.Adjective) };
            var result = meaningParser.WhatDoTheyWantAStoryAbout(words);

            Assert.Equal("Zebra", result.MainCharacter.Type);
            Assert.Equal("fat", result.MainCharacter.Adjective);
        }

        [Fact]
        public void WhatDoTheyWantAStoryAbout_WordsContainsAnimalAndFood_ReturnsContextWithCharacterInformation()
        {
            var words = new List<Word>() { new Word("Zebra", WordType.Animal), new Word("banana", WordType.Food) };
            var result = meaningParser.WhatDoTheyWantAStoryAbout(words);

            Assert.Equal("Zebra", result.MainCharacter.Type);
            Assert.Equal("banana", result.MainCharacter.Likes);
        }
    }
}
