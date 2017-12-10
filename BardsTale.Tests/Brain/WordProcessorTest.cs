using Xunit;
using BardsTale.Brain;
using BardsTale.Model;

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
        public void Process_KnownAnimal_ShouldReturnWordWithTypeAnimal()
        {
            var result = wordProcessor.Process("baboon");

            Assert.NotNull(result);
            Assert.Equal(WordType.Animal, result.Type);
        }


        [Fact]
        public void Process_KnownFood_ShouldReturnWordWithTypeFood()
        {
            var result = wordProcessor.Process("pizza");

            Assert.NotNull(result);
            Assert.Equal(WordType.Food, result.Type);
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

        [Fact]
        public void ProcessSentence_EmptyString_ReturnAnEmptyList(){
            var result = wordProcessor.ProcessSentence("");

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void ProcessSentence_MultipleSpaces_ReturnAnEmptyList()
        {
            var result = wordProcessor.ProcessSentence("   ");

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void ProcessSentence_OneWord_ReturnListWithWordAndType()
        {
            var result = wordProcessor.ProcessSentence("elephant");
            Assert.Equal(1, result.Count);
            Assert.Equal(WordType.Animal, result[0].Type);
        }

        [Fact]
        public void ProcessSentence_TwoWords_ReturnListWithTwoWords()
        {
            var result = wordProcessor.ProcessSentence("big elephant");
            Assert.Equal(2, result.Count);
            Assert.Equal(WordType.Adjective, result[0].Type);
            Assert.Equal(WordType.Animal, result[1].Type);
        }
    }
}

