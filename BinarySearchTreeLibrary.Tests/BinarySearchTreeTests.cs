using BinarySearchTreeLibrary.Tests.TestClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BinarySearchTreeLibrary.Tests
{
    public class BinarySearchTreeTests
    {
        [Test]
        public void BinaryTreeInteger_Test()
        {
            BinarySearchTree<int> binaryTree = new BinarySearchTree<int>() { 8, 5, 4, 9, 7, 11, 1, 12, 3, 2 };

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 11, 12 }, binaryTree.Inorder());
            CollectionAssert.AreEqual(new int[] { 8, 5, 4, 1, 3, 2, 7, 9, 11, 12 }, binaryTree.Preorder());
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 7, 9, 11, 12, 8 }, binaryTree.Postorder());
        }
        
        [Test]
        public void BinaryTreeString_Test()
        {
            BinarySearchTree<string> binaryTree = new BinarySearchTree<string>() { "BDDD", "ABB", "AAAA", "HHH", "EEE" };
            CollectionAssert.AreEqual(new string[] { "AAAA", "ABB", "BDDD", "EEE", "HHH" }, binaryTree.Inorder());
            CollectionAssert.AreEqual(new string[] { "BDDD", "ABB", "AAAA", "HHH", "EEE" }, binaryTree.Preorder());
            CollectionAssert.AreEqual(new string[] { "AAAA", "ABB", "EEE", "HHH", "BDDD" }, binaryTree.Postorder());
        }

        [Test]
        public void BookBinaryTree_Test()
        {
            BinarySearchTree<Book> binaryTree = new BinarySearchTree<Book>() {
                new Book("CLR via C#", "Richter",2012, 16800),
                new Book("Библия C#", "Фленов М.", 2016, 2400),
                new Book("C# 4.0 Полное руководство", "Voina i Mir",2019, 14400),
                new Book("C#. Сборник рецептов", "Павел Агуров",2007, 1500),
                new Book("С# без лишних слов", "Уильям Робисон",2017, 30000),
            };

            var expected = new Book[]
            {
                new Book("C#. Сборник рецептов", "Павел Агуров",2007, 1500),
                new Book("Библия C#", "Фленов М.", 2016, 2400),
                new Book("C# 4.0 Полное руководство", "Voina i Mir",2019, 14400),
                new Book("CLR via C#", "Richter",2012, 16800),
                new Book("С# без лишних слов", "Уильям Робисон",2017, 30000)
            };

            //int i = 0;
            //foreach (var item in binaryTree.Inorder())
            //{
            //    var exp = expected[i++];
            //    var result = item;
            //    Assert.AreEqual(expected[i++], item);
            //}

            // TODO: Expected is <BinarySearchTreeLibrary.Tests.TestClasses.Book[5]>, actual is <BinarySearchTreeLibrary.BinarySearchTree`1+<Inorder>d__22[BinarySearchTreeLibrary.Tests.TestClasses.Book]>
            CollectionAssert.AreEqual(new[] {
                new Book("C#. Сборник рецептов", "Павел Агуров",2007, 1500),
                new Book("Библия C#", "Фленов М.", 2016, 2400),
                new Book("C# 4.0 Полное руководство", "Voina i Mir",2019, 14400),
                new Book("CLR via C#", "Richter",2012, 16800),
                new Book("С# без лишних слов", "Уильям Робисон",2017, 30000)
            }, binaryTree.Inorder());
        }


        [Test]
        public void PointBinaryTreeTestWithComparison_CompareByYValue_TreeIncludeItElement()
        {
            BinarySearchTree<Point> binaryTree = new BinarySearchTree<Point>()
            {
                new Point(2, 5),
                new Point(4, 0),
                new Point(0, 4),
            };
            var expected = new BinarySearchTree<Point>()
            {
                new Point(0, 4),
                new Point(2, 5),
                new Point(4, 0),
            };

            Assert.IsTrue(binaryTree.Contains(new Point(4, 0)));
            //CollectionAssert.AreEqual(expectedPoints, testTree.Inorder());
        }

    }
}