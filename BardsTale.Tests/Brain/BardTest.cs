using System.Collections.Generic;

using Xunit;

using BardsTale.Brain;
using BardsTale.Model;

namespace BardsTale.Tests.Brain
{
    public class BardTest
    {
        private List<Word> keywords;

        Bard bard = new Bard(TestHelper.GetMainProjectDirectory());

        public BardTest()
        {
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

        const string SENTENCE = "A sentence with ";
        private Character MainCharacter = new Character() { Name = "BOB" };

        [Fact]
        public void FormatContextIntoSentence_FormatsMainCharacterName()
        {
            bard.Story = new StoryContext() { MainCharacter = new Character() { Name = "BOB" } };
            string formattedSentence = bard.FormatContextIntoSentence(SENTENCE + "[MAINCHAR]", new Word("Ball", WordType.Unknown));
            Assert.Equal(SENTENCE + "BOB", formattedSentence);
        }

        [Theory]
        [InlineData("[Noun]", "Ball", WordType.Noun, "Ball")]
        [InlineData("[Noun]", "BLABLA", WordType.Unknown, "coin")]
        [InlineData("[Food]", "Pizza", WordType.Food, "Pizza")]
        [InlineData("[Food]", "BLABLA", WordType.Unknown, "banana")]
        [InlineData("[Animal]", "Baboon", WordType.Animal, "Baboon")]
        [InlineData("[Adjective]", "Smart", WordType.Adjective, "Smart")]
        [InlineData("[Adjective]", "BLABLA", WordType.Unknown, "chubby")]
        [InlineData("[Verb]", "play", WordType.Verb, "play")]
        [InlineData("[Verb]", "BLABLA", WordType.Unknown, "jump")]
        [InlineData("[Color]", "blue", WordType.Color, "blue")]
        [InlineData("[Color]", "BLABLA", WordType.Unknown, "red")]
        [InlineData("[Location]", "forest", WordType.Location, "forest")]
        [InlineData("[Location]", "BLABLA", WordType.Unknown, "beach")]
        [InlineData("[Thing]", "seashells", WordType.Thing, "seashells")]
        [InlineData("[Thing]", "BLABLA", WordType.Unknown, "stones")]
        [InlineData("[Unknown]", "BLABLA", WordType.Unknown, "BLABLA")]
        public void FormatContextIntoSentence_FormatsWordIntoSentence(string sentenceParticle, string word, WordType type, string expectedFormat)
        {
            bard.Story = new StoryContext() { MainCharacter = MainCharacter };
            string formattedSentence = bard.FormatContextIntoSentence(SENTENCE + sentenceParticle, new Word(word, type));
            Assert.Equal(SENTENCE + expectedFormat, formattedSentence);
        }

        [Theory]
        [InlineData("[Animal]", "Ball", WordType.Unknown)]
        [InlineData("[Name]", "Ball", WordType.Unknown)]
        [InlineData("[PLOTTWIST]", "Ball", WordType.Unknown)]
        public void FormatContentIntoSentence_WithRandomisedContent(string sentenceParticle, string word, WordType type){
            bard.Story = new StoryContext() { MainCharacter = MainCharacter };
            string formattedSentence = bard.FormatContextIntoSentence(SENTENCE + sentenceParticle, new Word(word, type));
            Assert.False(formattedSentence.Contains(sentenceParticle));
        }
    }
}
