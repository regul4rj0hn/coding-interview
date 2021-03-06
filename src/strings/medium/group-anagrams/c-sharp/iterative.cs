using System;
using System.Collections.Generic;
using System.Linq;

/*
This solution relies on ordering each word on the input list alphabetically, and then ordering the resulted array alphabetically as well.
Once that is done, we need to map the indices on our new sorted array to the original words/ordering on the input string.
To construct the output string we loop through these indexes and compare the word on the -index- position on our original array, with the sorted one.
If it matches, we add it. If it doesn't match it means we need to create a new list of anagrams for the next group.

This solution sucks.

Time : O(w.n.log(n) + w.n.log(w)) - Where W is the number of words and N is the length of the longest word
Space: O(w.n)                     - To store the words for the output
*/
class Program {
    public static List<List<string>> groupAnagrams (List<string> words) {
        var output = new List<List<string>> ();

        if (words.Count == 0) {
            return output;
        }

        var sortedWords = new List<string> ();
        foreach (var word in words) {
            sortedWords.Add (SortAlphabetically (word));
        }

        var indices = Enumerable.Range (0, words.Count).ToList ();
        indices.Sort ((a, b) => sortedWords[a].CompareTo (sortedWords[b]));

        var currentAnagramList = new List<string> ();
        var currentAnagram = sortedWords[indices[0]];

        foreach (var index in indices) {
            var word = words[index];
            var sorted = sortedWords[index];

            if (sorted.Equals (currentAnagram)) {
                currentAnagramList.Add (word);
                continue;
            }

            output.Add (currentAnagramList);
            currentAnagramList = new List<string> () { word };
            currentAnagram = sorted;
        }

        output.Add (currentAnagramList);

        return output;
    }

    private static string SortAlphabetically (string str) {
        var chars = str.ToArray ();
        Array.Sort (chars);
        return new string (chars);
    }
}