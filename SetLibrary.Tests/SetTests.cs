using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SetLibrary.Tests
{
    public class SetTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { 5, 6, 7, 8, 9, 10, 11, 12 })]
        public void Add_Tests(int[] array)
        {
            Set<int> set = new Set<int>();
            foreach (int item in array)
            {
                set.Add(item);
            }

            CollectionAssert.AreEqual(array, set);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 7, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 8 })]
        [TestCase(new int[] { 5, 6, 7, 8, 9, 10, 11, 12 }, 7, ExpectedResult = new int[] { 5, 6, 8, 9, 10, 11, 12 })]
        public IEnumerable<int> Remove_Tests(int[] array, int element)
        {
            Set<int> set = new Set<int>(array);
            set.Remove(element);

            return set;
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 5, 6, 7, 8, 9, 10, 11, 12 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 })]
        public IEnumerable<int> Union_Tests(int[] first, int[] second)
        {
            return new Set<int>(first).Union(new Set<int>(second));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 5, 6, 7, 8, 9, 10, 11, 12 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 5, 6, 7, 8, 9, 10, 11, 12 })]
        public IEnumerable<int> Concat_Tests(int[] first, int[] second)
        {
            return new Set<int>(first).Concat(new Set<int>(second));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 5, 6, 7, 8, 9, 10, 11, 12 }, ExpectedResult = new int[] { 5, 6, 7, 8 })]
        public IEnumerable<int> Intersect_Tests(int[] first, int[] second)
        {
            return new Set<int>(first).Intersect(new Set<int>(second));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 5, 6, 7, 8, 9, 10, 11, 12 }, ExpectedResult = new int[] { 1, 2, 3, 4 })]
        public IEnumerable<int> Except_Tests(int[] first, int[] second)
        {
            return new Set<int>(first).Except(new Set<int>(second));
        }

        [TestCase(new int[] { 1, 1, 2, 3, 2, 1, 4, 5, 8, 6, 7, 8 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5, 8, 6, 7 })]
        public IEnumerable<int> Distinct_Tests(int[] array)
        {
            return new Set<int>(array).Distinct();
        }
    }
}