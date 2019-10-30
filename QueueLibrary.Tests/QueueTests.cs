using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace QueueLibrary.Tests
{
    public class QueueTests
    {

        [TestCase(new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { -18, 15 })]
        [TestCase(new int[] { -500 })]
        [TestCase(new int[] { 13, 15, 25, 26, -36, -38, -39, -48, 56, 1050 })]
        public void Dequeue_Test(int[] array)
        {
            Queue<int> queue = new Queue<int>(array);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(array[i], queue.Dequeue());
            }
        }

        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { -5, 15 })]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { 17, 11 })]
        public void Enqueue_Test(int[] array)
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < array.Length; i++)
            {
                queue.Enqueue(array[i]);
            }

            CollectionAssert.AreEqual(array, queue);
        }

        [Test]
        public void Contains_Test()
        {
            Node<string> ivan = new Node<string>("Ivan");
            Node<string> kate = new Node<string>("Kate");


            Queue<Node<string>> queue = new Queue<Node<string>>();
            queue.Enqueue(new Node<string>("Ivan"));
            queue.Enqueue(kate);
            Assert.IsFalse(queue.Contains(ivan));
            Assert.IsTrue(queue.Contains(kate));
        }

        [Test]
        public void ConstructorTest_InputIncorrectData_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new Queue<string>().Enqueue(null));

        [TestCase(new int[] { -1 }, ExpectedResult = -1)]
        [TestCase(new int[] { 12, 15 }, ExpectedResult = 12)]
        [TestCase(new int[] { 154, 18, 295 }, ExpectedResult = 154)]
        [TestCase(new int[] { 13, 17, 18, 19, 20, 21, 23, 11 }, ExpectedResult = 13)]
        public int PeekTest_DifferentValues_AssertInputedValues(int[] sourceArray)
            => new Queue<int>(sourceArray).Peek();
    }
}