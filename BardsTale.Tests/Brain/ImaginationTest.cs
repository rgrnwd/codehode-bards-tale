using Xunit;
using BardsTale.Brain;
using System.Collections.Generic;
using BardsTale.Model;

namespace BardsTale.Tests.Brain
{
    public class ImaginationTest
    {
        static Memory memory = new Memory(TestHelper.GetMainProjectDirectory());
        Imagination imagination = new Imagination(memory);

        [Fact]
        public void MakeUpSomeRandomName_ReturnsValue()
        {
            var result = imagination.MakeUpSomeRandomName();

            Assert.True(result.Length > 2);
        }

        [Fact]
        public void MakeUpSomeRandomName_ReturnsDifferentValues()
        {
            List<string> names = new List<string>();
           
            for (int i = 0; i < 10; i++)
            {
                string newName = imagination.MakeUpSomeRandomName();
                if (!names.Contains(newName))
                    names.Add(newName);
            }

            Assert.True(names.Count > 3);
        }

        [Fact]
        public void MakeUpBeginning_ShouldStartWithOnceUponATime(){
            StoryContext context = new StoryContext();
            context.MainCharacter = new Character("baboon", "Bob", "silly", "fruit");
            var result = imagination.MakeUpBeginning(context);

            Assert.Contains("Once upon a time", result);
        }

        [Theory]
        [InlineData(WordType.Noun)]
        [InlineData(WordType.Animal)]
        [InlineData(WordType.Food)]
        [InlineData(WordType.Adjective)]
        [InlineData(WordType.Verb)]
        [InlineData(WordType.Name)]
        [InlineData(WordType.Unknown)]
        public void RandomiseSentenceWithWordType_ShouldFindSuitableSentenceInDictionary(WordType wordType)
        {
            var result = imagination.RandomiseSentenceWithWordType(wordType);
            Assert.Contains("[" + wordType.ToString() + "]", result);
        }
    }
}
