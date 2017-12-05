using System;
using Xunit;
using BardsTale.Brain;
using BardsTale.Model;
using System.IO;

namespace BardsTale.Tests.Brain
{
    public class WordProcessorTest
    {
        private WordProcessor wordProcessor;

        public WordProcessorTest()
        {
            wordProcessor = new WordProcessor(TestHelper.GetMainProjectDirectory());
        }

        [Fact]
        public void Process_KnownVerb_ShouldReturnWordWithTypeVerb()
        {
            var result = wordProcessor.Process("sleep");

            Assert.NotNull(result);
            Assert.Equal(WordType.Verb, result.Type);
        }

        [Fact]
        public void Process_KnownNoun_ShouldReturnWordWithTypeNoun()
        {
            var result = wordProcessor.Process("child");

            Assert.NotNull(result);
            Assert.Equal(WordType.Noun, result.Type);
        }

        [Fact]
        public void Process_KnownAdjective_ShouldReturnWordWithTypeAdjective()
        {
            var result = wordProcessor.Process("pretty");

            Assert.NotNull(result);
            Assert.Equal(WordType.Adjective, result.Type);
        }

        [Fact]
        public void Process_UnknownWord_ShouldReturnWordWithTypeUnknown()
        {
            var result = wordProcessor.Process("scoobydoo");

            Assert.NotNull(result);
            Assert.Equal(WordType.Unknown, result.Type);
        }
    }
}

