using System.Collections.Generic;

using Xunit;

using BardsTale.Brain;
using BardsTale.Model;

namespace BardsTale.Tests.Brain
{
    public class BardTest
    {
        private List<Word> keywords;

        Bard bard = new Bard(null);

        public BardTest(){
            keywords = new List<Word>();
            keywords.Add(new Word("Zebra", WordType.Animal));
            keywords.Add(new Word("fat", WordType.Adjective));
            keywords.Add(new Word("eat", WordType.Verb));
            keywords.Add(new Word("pizza", WordType.Food));
        }

        [Fact]
        public void TellStory_SetsTheTitleOfTheStoryToIncludeTheCharactersCharacteristics()
        {
            var result = bard.TellStory(keywords);

            Assert.Contains("Zebra", result.Title);
            Assert.Contains("fat", result.Title);
            Assert.Contains("pizza", result.Title);
        }

        [Fact]
        public void TellStory_CreatesAStoryWithACharacter()
        {
            var result = bard.TellStory(keywords);

            Assert.NotNull(result.MainCharacter);
            Assert.Equal("Zebra", result.MainCharacter.Type);
            Assert.Equal("fat", result.MainCharacter.Adjective);
            Assert.Equal("pizza", result.MainCharacter.FavouriteFood);
        }

        [Fact]
        public void TellStory_CreatesAStoryWithContent()
        {
            var result = bard.TellStory(keywords);

            Assert.True(result.Content.Count > 5);
        }
    }
}
