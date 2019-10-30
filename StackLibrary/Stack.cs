// <copyright file="Stack.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace StackLibrary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Stack.
    /// </summary>
    /// <typeparam name="T">Type of object.</typeparam>
    public class Stack<T> : IEnumerable<T>
    {
        private Node<T> Head { get; set; }

        private int Count { get; set; }

        /// <summary>
        /// Gets a value indicating whether returns an empty Set.
        /// </summary>
        /// <returns>True if empty. False if doesn't.</returns>
        public bool IsEmpty() => this.Count == 0;

        /// <summary>
        /// Push an element to the Stack.
        /// </summary>
        /// <param name="item">Element to add.</param>
        public void Push(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Node<T> node = new Node<T>(item)
            {
                Next = this.Head,
            };
            this.Head = node;
            this.Count++;
        }

        /// <summary>
        /// Push an element from the Stack.
        /// </summary>
        /// <returns>Removed element.</returns>
        public T Pop()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            Node<T> temp = this.Head;
            this.Head = this.Head.Next;
            this.Count--;

            return temp.Data;
        }

        /// <summary>
        /// Returns the object at the beginning of the without removing it.
        /// </summary>
        /// <returns>The object at the beginning of the Stack.</returns>
        public T Peek()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return this.Head.Data;
        }

        /// <summary>
        /// Return an enumerator that iterates over the set.
        /// </summary>
        /// <returns> An enumerator that can be used to iterate through a collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Return an enumerator that iterates over the set.
        /// </summary>
        /// <returns> An enumerator that can be used to iterate through a collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
