// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SetLibrary
{
    /// <summary>
    /// A class that will represent a single Set object.
    /// </summary>
    /// <typeparam name="T">Type of object.</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="data">Element.</param>
        public Node(T data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Gets or sets Element.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets link to the next Node.
        /// </summary>
        public Node<T> Next { get; set; }
    }
}
