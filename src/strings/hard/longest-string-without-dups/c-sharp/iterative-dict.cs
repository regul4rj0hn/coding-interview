using System;
using System.Collections.Generic;

/*
To solve the problem traverse the input string and store the last position at which each character was seen in a hash table. Additionally, we keep track of two more things: a starting index variable which should represent the most recent index from which you could start a substring with no duplicate characters (ending at our current index); along with the two indices that delimit our current longest sub-string.

Given these three elements, use the hash table to update the start index variable, while updating the longest sub-string begin and end indices as we loop through the array:
 - The start index needs to be updated only if the current character is found on our hash map, taking the maximum between our current start and the index where we last saw the current char, that's stored in our hash: Max(start, lastSeen[ch] + 1)
 - The longest sub-string needs to be updated only when the current length (longest[1]-longest[0]) is _shorter than_ the length given by the next index position and our start marker (index + 1 - start) 
 - The last seen hash map needs to be updated on each iteration no matter what

The output should be the sub-string taken from the original input string that's delimited by our stored longest sub-string limits (starts at longest[0] and of length longest[1]-longest[0]).

Time : O(n)         - Where N is the length of the input string
Space: O(min(n, a)) - Where A is the length of the character alphabet represented in the input string
*/
public class Program {
    public static string LongestSubstringWithoutDuplication(string str) {
        var lastSeen = new Dictionary<char, int>();
        var longest = new int[] { 0, 1 };
        var start = 0;

        for (var i = 0; i < str.Length; i++) {
            var ch = str[i];
            if (lastSeen.ContainsKey(ch)) {
                start = Math.Max(start, lastSeen[ch] + 1);
            }
            if (longest[1] - longest[0] < i + 1 - start) {
                longest = new int[] { start, i + 1 };
            }
            lastSeen[ch] = i;
        }

        return str.Substring(longest[0], longest[1] - longest[0]);
    }
}
