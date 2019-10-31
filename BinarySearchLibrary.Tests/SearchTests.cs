using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BinarySearchLibrary.Tests
{
    public class SearchTests
    {
        [TestCase(new int[] { 0, 1, 3, 4, 6, 6, 7, 7, 124, 21234, 324234 }, 21234, 9)]
        [TestCase(new int[] { 0, 1, 3, 4, 6, 7 }, 4, 3)]
        [TestCase(new int[] { 0, 1, 3, 4, 6, 7 }, 0, 0)]
        [TestCase(new int[] { 0, 1, 3, 4, 6, 7 }, 7, 5)]
        public void Int_BinarySearch(int[] array, int element, int expectedResult) 
            => Assert.AreEqual(expectedResult, BinarySearch.Search(array, element, Comparer<int>.Default));

        [TestCase(new double[] { 0.2, 1.3, 4.6, 5.2, 7.4, 8.1 }, 4.6, ExpectedResult = 2)]
        [TestCase(new double[] { 0.12, 1.121,  1.1212, 1.123, 0.124, 1.126}, 1.121, ExpectedResult = 1)]
        public int? Double_BinarySearch(double[] array, double element) 
            => BinarySearch.Search(array, element, Comparer<double>.Default);

        [TestCase(new string[] { "aaa", "ab", "ba", "bba", "bbb" }, "ab", 1)]
        [TestCase(new string[] { "aaa", "ab", "ba", "bba", "bbb" }, "bba", 3)]
        public void String_BinarySearch(string[] array, string element, int expectedResult) 
            => Assert.AreEqual(expectedResult, BinarySearch.Search(array, element, Comparer<string>.Default));

        [TestCase(null, "aaa")]
        [TestCase(new string[] { "aaa", "ab", "ba", "bba", "bbb" }, null)]
        public void NullException_BinarySearch(string[] array, string element) 
            => Assert.Throws<ArgumentNullException>(() => BinarySearch.Search(array, element, Comparer<string>.Default));

        [TestCase(new string[] { "aaa", "ab", "ba", "bba", "bbb" }, "bbc")]
        public void Exception_BinarySearch(string[] array, string element) 
            => Assert.Throws<ArgumentException>(() => BinarySearch.Search(array, element, Comparer<string>.Default));
    }
}