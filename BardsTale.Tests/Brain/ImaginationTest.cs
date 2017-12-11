using Xunit;
using BardsTale.Brain;
using System.Collections.Generic;

namespace BardsTale.Tests.Brain
{
    public class ImaginationTest
    {
        Imagination imagination = new Imagination();

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

            Assert.True(names.Count > 5);
        }
    }
}
