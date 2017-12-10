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

        [Fact]
        public void FindSubjectOfTheStory_EmptyListOfWords_ThrowError()
        {
            MeaningParser meaningParser = new MeaningParser(new List<Word>());
            Exception ex = Assert.Throws<InvalidInputException>(() =>  meaningParser.FindSubjectOfTheStory());

        }
    }
}
