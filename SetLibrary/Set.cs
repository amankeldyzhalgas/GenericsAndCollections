// <copyright file="Set.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SetLibrary
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Set.
    /// </summary>
    /// <typeparam name="T">Type of object.</typeparam>
    public class Set<T> : IEnumerable<T>
    {
        private Node<T> Head { get; set; }

        private Node<T> Tail { get; set; }

        private int Count { get; set; }

        /// <summary>
        /// Gets a value indicating whether returns an empty Set.
        /// </summary>
        /// <returns>True if empty. False if doesn't.</returns>
        public bool IsEmpty() => this.Count == 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Set{T}"/> class.
        /// </summary>
        public Set()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Set{T}"/> class.
        /// </summary>
        /// <param name="collection">Collection to copy elements from.</param>
        public Set(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"Collection {nameof(collection)} haves null value");
            }

            IEnumerator<T> enumerator = collection.GetEnumerator();

            while (enumerator.MoveNext())
            {
                this.Add(enumerator.Current);
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
        /// Remove the element from the set.
        /// </summary>
        /// <param name="data">Element to remove.</param>
        public void Remove(T data)
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Set is empty");
            }

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (!this.Contains(data))
            {
                throw new KeyNotFoundException($"The {data} element was not found in the set.");
            }

            Node<T> current = this.Head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            this.Tail = previous;
                        }
                    }
                    else
                    {
                        this.Head = this.Head.Next;
                        if (this.Head == null)
                        {
                            this.Tail = null;
                        }
                    }

                    this.Count--;
                }

                previous = current;
                current = current.Next;
            }
        }

        /// <summary>
        /// Returns the set union, which means unique elements.
        /// that appear in either of two collections.
        /// </summary>
        /// <param name="set">Set.</param>
        /// <returns>New Set.</returns>
        public Set<T> Union(Set<T> set)
        {
            if (set is null)
            {
                throw new ArgumentNullException(nameof(set));
            }

            var resultSet = new Set<T>();

            foreach (var item in this)
            {
                resultSet.Add(item);
            }

            foreach (var item in from item in set
                                 where !resultSet.Contains(item)
                                 select item)
            {
                resultSet.Add(item);
            }

            return resultSet;
        }

        /// <summary>
        /// Produces the set union.
        /// </summary>
        /// <param name="set">Set.</param>
        /// <returns>New Set.</returns>
        public Set<T> Concat(Set<T> set)
        {
            if (set is null)
            {
                throw new ArgumentNullException(nameof(set));
            }

            var resultSet = new Set<T>();

            foreach (var item in this)
            {
                resultSet.Add(item);
            }

            foreach (var item in set)
            {
                resultSet.Add(item);
            }

            return resultSet;
        }

        /// <summary>
        /// Returns the set intersection, which means elements.
        /// that appear in each of two collections.
        /// </summary>
        /// <param name="set">Set.</param>
        /// <returns>New Set.</returns>
        public Set<T> Intersect(Set<T> set)
        {
            if (set is null)
            {
                throw new ArgumentNullException(nameof(set));
            }

            var resultSet = new Set<T>();
            foreach (var item in from item in this
                                 where set.Contains(item)
                                 select item)
            {
                resultSet.Add(item);
            }

            return resultSet;
        }

        /// <summary>
        /// Returns the set difference, which means the elements of one collection.
        /// that do not appear in a second collection.
        /// </summary>
        /// <param name="set">Set.</param>
        /// <returns>New Set.</returns>
        public Set<T> Except(Set<T> set)
        {
            if (set is null)
            {
                throw new ArgumentNullException(nameof(set));
            }

            var resultSet = new Set<T>();

            foreach (var item in from item in this
                                 where !set.Contains(item)
                                 select item)
            {
                resultSet.Add(item);
            }

            return resultSet;
        }

        /// <summary>
        /// Removes duplicate values from a collection.
        /// </summary>
        /// <returns>New Set.</returns>
        public Set<T> Distinct()
        {
            var resultSet = new Set<T>();

            foreach (var item in from item in this
                                 where !resultSet.Contains(item)
                                 select item)
            {
                resultSet.Add(item);
            }

            return resultSet;
        }

        /// <summary>
        /// Determines whether an element is in the Set.
        /// </summary>
        /// <param name="data">Data.</param>
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
