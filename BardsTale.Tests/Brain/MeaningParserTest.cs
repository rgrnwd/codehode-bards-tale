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

            Assert.Contains("Zebra", result.MainCharacter.Type);
        }
    }
}
