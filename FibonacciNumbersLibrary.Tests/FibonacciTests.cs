using NUnit.Framework;
using System.Numerics;

namespace FibonacciNumbersLibrary.Tests
{
    public class FibonacciTests
    {
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        public void FibonacciGeneratorTests(ulong[] expected, int count)
        {
            ulong[][] expecteds =
                {
                new ulong[] { 0 },
                new ulong[] { 0, 1 },
                new ulong[] { 0, 1, 1 },
                new ulong[] { 0, 1, 1, 2 },
                new ulong[] { 0, 1, 1, 2, 3 },
                new ulong[] { 0, 1, 1, 2, 3, 5 },
                new ulong[] { 0, 1, 1, 2, 3, 5, 8 }
                };
            int[] counts = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            for (int i = 0; i < counts.Length; i++)
            {
                CollectionAssert.AreEqual(expecteds[i], FibonacciNumbers.Fibonacci(counts[i]));
            }
        }
    }
}