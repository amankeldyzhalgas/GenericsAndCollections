// <copyright file="FibonacciNumbers.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FibonacciNumbersLibrary
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Generates Fibonacci sequence.
    /// </summary>
    public class FibonacciNumbers
    {
        /// <summary>
        /// Generates the fibonacci.
        /// </summary>
        /// <param name="count">Length of the sequence.</param>
        /// <returns>Fibonacci.</returns>
        public static IEnumerable<ulong> Fibonacci(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException("Sequence Length should be bigger than 0!");
            }

            return FibonacciGenerator(count);
        }

        private static IEnumerable<ulong> FibonacciGenerator(int count)
        {
            ulong bprev = 0;
            ulong prev = 1;

            for (int i = 0; i < count; ++i)
            {
                yield return bprev;
                Swap(ref prev, ref bprev);
            }
        }

        private static void Swap(ref ulong first, ref ulong second)
        {
            var temp = first;
            first += second;
            second = temp;
        }
    }
}
