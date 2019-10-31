using NUnit.Framework;
using System.Collections.Generic;

namespace StackLibrary.Tests
{
    public class StackTests
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 8, 7, 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 5, 6, 7, 8, 9, 10, 11, 12 }, new int[] { 12, 11, 10, 9, 8, 7, 6, 5 })]
        public void Push_Tests(int[] array, int[] expected)
        {
            Stack<int> stack = new Stack<int>();
            foreach (int item in array)
            {
                stack.Push(item);
            }
            
            CollectionAssert.AreEqual(expected, stack);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, ExpectedResult = 8)]
        [TestCase(new int[] { 5, 6, 7, 8, 9, 10, 11, 12 }, ExpectedResult = 12)]
        public int Pop_Tests(int[] array)
        {
            Stack<int> stack = new Stack<int>(array);
            return stack.Pop();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, ExpectedResult = 7)]
        [TestCase(new int[] { 5, 6, 7, 8, 9, 10, 11, 12 }, ExpectedResult = 11)]
        public int Peek_Tests(int[] array)
        {
            Stack<int> stack = new Stack<int>(array);
            stack.Pop();
            return stack.Peek();
        }
    }
}