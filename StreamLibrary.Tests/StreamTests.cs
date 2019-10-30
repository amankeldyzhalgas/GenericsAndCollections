using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;

namespace StreamLibrary.Tests
{
    public class StreamTests
    {
        [Test()]
        public void Test()
        {
            string filePath = "Test.txt";
            List<string> words = new List<string> { "test", "file", "of" };
            Dictionary<string, int> expected = new Dictionary<string, int>(3)
            {
                { "test", 3 },
                { "file", 3 },
                { "of", 6 }
            };
            var result = Stream.FrequencyWords(filePath, words);

            CollectionAssert.AreEqual(expected, result);
        }
    }
}