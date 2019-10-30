using NUnit.Framework;
using System;

namespace SetLibrary.Tests
{
    public class SetTests
    {
        [Test]
        public void Test1()
        {
            var set1 = new Set<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8
            };
            set1.Add(7);
            PrintSet(set1, "set1: ");
            var set2 = new Set<int>()
            {
                5, 6, 7, 8, 9, 10, 11, 12
            };
            PrintSet(set2, "set2: ");
            var set3 = new Set<int>()
            {
                5, 5, 5, 6, 7, 8, 9, 10, 11, 12
            };
            PrintSet(set3, "set3: ");
            var UnionSet = set1.Union(set2);
            //UnionSet.Remove(5);
            PrintSet(UnionSet, "unionSet: ");
            var ConcatSet = set1.Concat(set2);
            PrintSet(ConcatSet, "concatSet: ");
            var IntersectionSet = set1.Intersect(set2);
            PrintSet(IntersectionSet, "IntersectionSet: ");
            var DifferencenSet = set1.Except(set2);
            PrintSet(DifferencenSet, "DifferencenSet: ");
            PrintSet(set3, "set3: ");
            var dSet3 = set3.Distinct();
            PrintSet(dSet3, "set3: ");
        }
        private static void PrintSet(Set<int> set, string title)
        {
            Console.Write(title);
            foreach (var item in set)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}