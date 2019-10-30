using NUnit.Framework;
using System.Collections.Generic;

namespace BinarySearchLibrary.Tests
{
    public class SearchTests
    {
        [TestCase(new int[] { 0, 1, 3, 4, 6, 6, 7, 7, 124, 21234, 324234 }, 21234, 9)]
        [TestCase(new int[] { 0, 1, 3, 4, 6, 7 }, 4, 3)]
        [TestCase(new int[] { 0, 1, 3, 4, 6, 7 }, 0, 0)]
        [TestCase(new int[] { 0, 1, 3, 4, 6, 7 }, 7, 5)]
        public void BinarySearch_Int(int[] array, int element, int expectedResult)
        {
            Assert.AreEqual(expectedResult, BinarySearch.Search(array, element, Comparer<int>.Default));
        }

        [TestCase(new double[] { 0.312, 1.235, 3.56, 5.002, 7.1234, 9.1231 }, 3.56, ExpectedResult = 2)]
        [TestCase(new double[] { 0.312, 0.312123, 0.3128797, 0.31299999 }, 0.3128797, ExpectedResult = 2)]
        public int? BinarySearch_Double(double[] array, double element)
        {
            return BinarySearch.Search(array, element, Comparer<double>.Default);
        }

        [TestCase(new string[] { "aaaa", "aaaaa", "ab", "bv", "vc" }, "ab", 2)]
        [TestCase(new string[] { "aaaa", "aaaaa", "ab", "bv", "vc" }, "aaaa", 0)]
        [TestCase(new string[] { "aaaa", "aaaaa", "ab", "bv", "vc" }, "aaaaa", 1)]
        [TestCase(new string[] { "aaaa", "aaaaa", "ab", "bv", "vc" }, "vc", 4)]
        public void BinarySearch_String(string[] array, string element, int expectedResult)
        {
            Assert.AreEqual(expectedResult, BinarySearch.Search(array, element, Comparer<string>.Default));
        }
    }
}