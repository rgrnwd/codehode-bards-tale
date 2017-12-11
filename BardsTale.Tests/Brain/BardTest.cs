using System.Collections.Generic;

using Xunit;

using BardsTale.Brain;
using BardsTale.Model;

namespace BardsTale.Tests.Brain
{
    public class BardTest
    {
        Bard bard = new Bard();

        [Fact]
        public void TellStory_SetsTheTitleOfTheStory()
        {
            var keywords = new List<Word>() { new Word("Zebra", WordType.Animal) };
            var result = bard.TellStory(keywords);

            Assert.Contains("Zebra", result.Title);
        }

        [Fact]
        public void TellStory_CreatesAStoryWithACharacter()
        {
            var keywords = new List<Word>() { new Word("Zebra", WordType.Animal) };
            var result = bard.TellStory(keywords);

            Assert.NotNull(result.MainCharacter);
        }
    }
}
