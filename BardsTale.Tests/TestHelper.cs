using System;
using System.IO;

namespace BardsTale.Tests
{
    public static class TestHelper
    {
        public static String GetMainProjectDirectory()
        {
            var solutionFolder = AppContext.BaseDirectory.Substring(0,
              AppContext.BaseDirectory.IndexOf("BardsTale.Tests", StringComparison.OrdinalIgnoreCase));

            return Path.Combine(solutionFolder, "BardsTale");
        }
    }
}
