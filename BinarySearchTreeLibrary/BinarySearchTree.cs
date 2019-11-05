// <copyright file="BinarySearchTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinarySearchTreeLibrary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// BinarySearchTree.
    /// </summary>
    /// <typeparam name="T">Type of object.</typeparam>
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private Node<T> Root { get; set; }

        private IComparer<T> Comparer { get; set; }

        private int Count { get; set; }

        /// <summary>
        /// Gets a value indicating whether returns an empty Set.
        /// </summary>
        /// <returns>True if empty. False if doesn't.</returns>
        public bool IsEmpty() => this.Count == 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree()
            : this(Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">Compare two elements.</param>
        public BinarySearchTree(IComparer<T> comparer)
        {
            if (comparer is null)
            {
                this.Comparer = Comparer<T>.Default;
            }

            this.Comparer = comparer;
            try
            {
                comparer.Compare(default, default);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="elements">collection for initialization.</param>
        public BinarySearchTree(IEnumerable<T> elements)
            : this(elements, Comparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="elements">collection for initialization.</param>
        /// <param name="comparer">compare two elements.</param>
        public BinarySearchTree(IEnumerable<T> elements, IComparer<T> comparer)
            : this(comparer)
        {
            foreach (T item in elements)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Add data to the set.
        /// </summary>
        /// <param name="data">Element to add.</param>
        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Node<T> node = new Node<T>(data);
            if (this.Root is null)
            {
                this.Root = node;
            }
            else
            {
                Node<T> current = this.Root;
                Node<T> parent = null;
                while (current != null)
                {
                    parent = current;
                    if (this.Comparer.Compare(data, current.Data) < 0)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }

                if (this.Comparer.Compare(data, parent.Data) < 0)
                {
                    parent.Left = node;
                }
                else
                {
                    parent.Right = node;
                }
            }

            ++this.Count;
        }

        /// <summary>
        /// Remove element from the binary tree.
        /// </summary>
        /// <param name="data">element which must be removed.</param>
        public void Remove(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException($"Elemnt {nameof(data)} haves null value");
            }

            Node<T> current = this.Root;
            Node<T> parent = null;
            while (this.Comparer.Compare(data, current.Data) != 0)
            {
                if (this.Comparer.Compare(data, current.Data) < 0)
                {
                    parent = current;
                    current = current.Left;
                    if (current == null)
                    {
                        break;
                    }
                }
                else
                {
                    parent = current;
                    current = current.Right;
                    if (current == null)
                    {
                        break;
                    }
                }
            }

            if (current.Right == null)
            {
                if (current == this.Root)
                {
                    this.Root = current.Left;
                }
                else
                {
                    if (this.Comparer.Compare(current.Data, parent.Data) < 0)
                    {
                        parent.Left = current.Left;
                    }
                    else
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (current == this.Root)
                {
                    this.Root = current.Right;
                }
                else
                {
                    if (this.Comparer.Compare(current.Data, parent.Data) < 0)
                    {
                        parent.Left = current.Right;
                    }
                    else
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                Node<T> minElement = current.Right.Left;
                Node<T> previous = current.Right;
                while (minElement.Left != null)
                {
                    previous = minElement;
                    minElement = minElement.Left;
                }

                previous.Left = minElement.Right;
                minElement.Left = current.Left;
                minElement.Right = current.Right;

                if (current == this.Root)
                {
                    this.Root = minElement;
                }
                else
                {
                    if (this.Comparer.Compare(current.Data, parent.Data) < 0)
                    {
                        parent.Left = minElement;
                    }
                    else
                    {
                        parent.Right = minElement;
                    }
                }
            }
        }

        /// <summary>
        /// Determines whether an element is in the BinaryTree.
        /// </summary>
        /// <param name="data">Data.</param>
        /// <returns>True if contains. False if doesn't.</returns>
        public bool Contains(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException($"Element {nameof(data)} haves null value");
            }

            return this.Find(data, this.Root) != null;
        }

        /// <summary>
        /// Clear Tree.
        /// </summary>
        public void Clear()
        {
            this.Root = null;
            this.Count = 0;
        }

        /// <summary>
        /// Traverse in the pre order.
        /// </summary>
        /// <returns>collection by current traversal.</returns>
        public IEnumerable<T> Preorder()
        {
            if (this.Root is null)
            {
                throw new InvalidOperationException("The tree is empty.");
            }

            return this.Preorder(this.Root);
        }

        /// <summary>
        /// Traverse in the in order.
        /// </summary>
        /// <returns>collection by current traversal.</returns>
        public IEnumerable<T> Inorder()
        {
            if (this.Root is null)
            {
                throw new InvalidOperationException("The tree is empty.");
            }

            return this.Inorder(this.Root);
        }

        /// <summary>
        /// Traverse in the post order.
        /// </summary>
        /// <returns>collection by current traversal.</returns>
        public IEnumerable<T> Postorder()
        {
            if (this.Root is null)
            {
                throw new InvalidOperationException("Tree is empty!");
            }

            return this.Postorder(this.Root);
        }

        private IEnumerable<T> Preorder(Node<T> node)
        {
            yield return node.Data;
            if (node.Left != null)
            {
                foreach (var item in this.Preorder(node.Left))
                {
                    yield return item;
                }
            }

            if (node.Right != null)
            {
                foreach (var item in this.Preorder(node.Right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> Inorder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var element in this.Inorder(node.Left))
                {
                    yield return element;
                }
            }

            yield return node.Data;

            if (node.Right != null)
            {
                foreach (var element in this.Inorder(node.Right))
                {
                    yield return element;
                }
            }
        }

        private IEnumerable<T> Postorder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var element in this.Inorder(node.Left))
                {
                    yield return element;
                }
            }

            if (node.Right != null)
            {
                foreach (var element in this.Inorder(node.Right))
                {
                    yield return element;
                }
            }

            yield return node.Data;
        }

        private Node<T> Find(T element, Node<T> node)
        {
            if (node is null)
            {
                return null;
            }

            if (this.Comparer.Compare(node.Data, element) == 0)
            {
                return node;
            }

            if (this.Comparer.Compare(node.Data, element) > 0)
            {
                return this.Find(element, node.Left);
            }
            else
            {
                return this.Find(element, node.Right);
            }
        }

        /// <summary>
        /// Return an enumerator that iterates over the binary tree.
        /// </summary>
        /// <returns> An enumerator that can be used to iterate through a collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.Inorder().GetEnumerator();
        }

        /// <summary>
        /// Return an enumerator that iterates over the binary tree.
        /// </summary>
        /// <returns> An enumerator that can be used to iterate through a collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
