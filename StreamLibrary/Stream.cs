// <copyright file="Stream.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace StreamLibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// A class Implements an algorithm that allows
    /// to determine the frequency of occurrences of words in the text.
    /// </summary>
    public static class Stream
    {
        /// <summary>
        /// A function that allows to determine the frequency of occurrences of words in the text..
        /// </summary>
        /// <param name="filePath">The filePath path.</param>
        /// <param name="words">Words.</param>
        /// <returns>The frequency of occurrences.</returns>
        public static Dictionary<string, int> FrequencyWords(string filePath, List<string> words)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                if (words is null)
                {
                    throw new ArgumentNullException($"{nameof(words)} can't be null.");
                }

                var result = new Dictionary<string, int>();
                using (StreamReader stream = new StreamReader(filePath))
                {
                    while (!stream.EndOfStream)
                    {
                        string line = stream.ReadLine();
                        Algorithm(ref result, line, words);
                    }
                }

                return result;
            }

            throw new ArgumentException("Invadlid address");
        }

        private static void Algorithm(ref Dictionary<string, int> result, string line, List<string> words)
        {
            var lineWords = line.Split(' ');
            for (int i = 0; i < words.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < lineWords.Length; j++)
                {
                    if (lineWords[j].Equals(words[i]))
                    {
                        count++;
                    }
                }

                if (!result.ContainsKey(words[i]))
                {
                    result.Add(words[i], count);
                }
                else
                {
                    var rCount = result[words[i]];
                    result[words[i]] = rCount + count;
                }
            }
        }
    }
}
