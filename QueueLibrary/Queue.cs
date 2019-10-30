// <copyright file="Queue.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace QueueLibrary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Queue.
    /// </summary>
    /// <typeparam name="T">Type of object.</typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        private Node<T> Head { get; set; }

        private Node<T> Tail { get; set; }

        private int Count { get; set; }

        /// <summary>
        /// Gets a value indicating whether returns an empty Queue.
        /// </summary>
        /// <returns>True if empty. False if doesn't.</returns>
        public bool IsEmpty() => this.Count == 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class that is empty.
        /// </summary>
        public Queue()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class that contains.
        /// elements copied from the specified collection, has the same initial capacity
        /// as the number of elements copied.
        /// </summary>
        /// <param name="collection">Collection to copy elements from.</param>
        public Queue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"Collection {nameof(collection)} haves null value");
            }

            IEnumerator<T> enumerator = collection.GetEnumerator();

            while (enumerator.MoveNext())
            {
                this.Enqueue(enumerator.Current);
            }
        }

        /// <summary>
        /// Adds an element to the end of the Queue.
        /// </summary>
        /// <param name="data">Element to add.</param>
        public void Enqueue(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException($"Element {nameof(data)} haves null value");
            }

            Node<T> node = new Node<T>(data);
            Node<T> tempNode = this.Tail;
            this.Tail = node;

            if (this.Count == 0)
            {
                this.Head = this.Tail;
            }
            else
            {
                tempNode.Next = this.Tail;
            }

            this.Count++;
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the Queue.
        /// </summary>
        /// <returns>Object at the beginning of the Queue.</returns>
        public T Dequeue()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException();
            }

            T output = this.Head.Data;
            this.Head = this.Head.Next;
            this.Count--;

            return output;
        }

        /// <summary>
        /// Returns the object at the beginning of the without removing it.
        /// </summary>
        /// <returns>The object at the beginning of the Queue.</returns>
        public T Peek()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("The queue is empty. Can't dequeue from empty queue.");
            }

            return this.Head.Data;
        }

        /// <summary>
        /// Removes all Objects from the queue.
        /// </summary>
        public void Clear()
        {
            this.Head = null;
            this.Tail = null;
            this.Count = 0;
        }

        /// <summary>
        /// Determines whether an element is in the Queue.
        /// </summary>
        /// <param name="data">Item.</param>
        /// <returns>True if contains. False if doesn't.</returns>
        public bool Contains(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException($"Element {nameof(data)} haves null value");
            }

            Node<T> current = this.Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
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
