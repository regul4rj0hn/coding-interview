using System;
using System.Collections.Generic;
using System.Linq;

/*
This approach is not only more intuive but also more efficient and the code is a lot cleaner.
Create a hash map where the key is a word sorted aphabetically, and the value is a list of words from the input that, when sorted, match that key.
For each word on the input, order it alphabetically. If it is already on our hash, add the original word to the list for that key.
If it is not, add the new alphabetically sorted key to the hash map along with the original word on a new list of values.
Return a new list with the collection of values (list of anagrams) from our hash map.

Time : O(w.n.log(n)) - Where W is the number of words and N is the length of the longest word
Space: O(w.n)        - To store the hash map of anagram list of words for the output
*/
class Program {
    public static List<List<string>> groupAnagrams (List<string> words) {
        var hash = new Dictionary<string, List<string>> ();

        foreach (var word in words) {
            var key = SortAlphabetically (word);

            if (hash.ContainsKey (key)) {
                hash[key].Add (word);
            }
            else {
                hash.Add (key, new List<string> () { word });
            }
        }

        return hash.Values.ToList ();
    }

    private static string SortAlphabetically (string str) {
        var chars = str.ToArray ();
        Array.Sort (chars);
        return new string (chars);
    }
}