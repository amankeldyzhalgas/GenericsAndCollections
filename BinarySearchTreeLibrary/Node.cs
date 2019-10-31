// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinarySearchTreeLibrary
{
    /// <summary>
    /// A class that will represent a single BinaryTree object.
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
            this.Left = null;
            this.Right = null;
        }

        /// <summary>
        /// Gets or sets Element.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets link to the Left Node.
        /// </summary>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Gets or sets link to the Right  Node.
        /// </summary>
        public Node<T> Right { get; set; }
    }
}
