// <copyright file="BinarySearch.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BinarySearchLibrary
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Binary Search.
    /// </summary>
    public class BinarySearch
    {
        /// <summary>
        /// Binary Search.
        /// </summary>
        /// <typeparam name="T">Type of array.</typeparam>
        /// <param name="array">Array for searching.</param>
        /// <param name="element">The element, which will be found.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Position of element in array. If there is no such element returns -1.</returns>
        public static int? Search<T>(T[] array, T element, IComparer<T> comparer)
        {
            return Search<T>(array, element, comparer.Compare);
        }

        /// <summary>
        /// Binary Search.
        /// </summary>
        /// <typeparam name="T">Type of array.</typeparam>
        /// <param name="array">Array for searching.</param>
        /// <param name="element">The element.</param>
        /// <param name="comparison">The comparison.</param>
        /// <returns>Position of element in array. </returns>
        public static int? Search<T>(T[] array, T element, Comparison<T> comparison)
        {
            if (array is null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null.");
            }

            if (comparison is null)
            {
                throw new ArgumentNullException("{0} is null.", nameof(comparison));
            }

            if ((dynamic)element is null)
            {
                throw new ArgumentNullException($"{nameof(element)} can't be null.");
            }

            if (array.Length == 0)
            {
                return null;
            }

            if ((comparison(element, array[0]) < 0) || (comparison(element, array[array.Length - 1]) > 0))
            {
                throw new ArgumentException("Element is out of range!", nameof(element));
            }

            int first = 0;
            int last = array.Length;

            while (first < last)
            {
                int mid = first + ((last - first) / 2);

                if (comparison(element, array[mid]) <= 0)
                {
                    last = mid;
                }
                else
                {
                    first = mid + 1;
                }
            }

            if (comparison(array[last], element) == 0)
            {
                return last;
            }
            else
            {
                return null;
            }
        }
    }
}
