using System;
using System.Collections.Generic;

/*
As an improvement over the brute force approach, we build a hash table to store each character and the number of times it appears on our input string.

Once we've built the character frequency hash, we traverse the string and return the first one that appears only once. Otherwise we return -1.

Time : O(n) - Where N is the length of the input string
Space: O(1) - The dictionary to hold the character frequency is of constant size, equal to the number of letters in the alphabet (27), so the space complexity is also constant
*/
public class Program{
    public int FirstNonRepeatingCharacter (string str) {
        var charFrequency = new Dictionary<char, int>();

        for (var i = 0; i < str.Length; i++) {
            var current = str[i];
            charFrequency[current] = charFrequency.GetValueOrDefault (current, 0) + 1;
        }

        for (int j = 0; j < str.Length; j++) {
            var character = str[j];
            if (charFrequency[character] == 1) {
                return j;
            }
        }

        return -1;
    }
}
