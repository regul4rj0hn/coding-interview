using System;
using System.Collections.Generic;

/*
Expanding on the character count approach, we can use an auxiliary hash data structure. We can start by counting all the characters in the character string and storing them on the hash. Then loop through the document string checking whether each character is in the hash table and has a value greater than zero (there are characters available) or not. If the character is in the hash, decrement the count for that character, otherwise we just return false.

Time : O(n + m) - Where N is the length of the document string, and M the length of the chars string
Space: O(c)     - Where C is the number of unique characters in the characters input string
*/
public class Program {
    public bool GenerateDocument (string characters, string document) {
        var charCounts = new Dictionary<char, int> ();

        for (int i = 0; i < characters.Length; i++) {
            var character = characters[i];
            charCounts[character] = charCounts.GetValueOrDefault (character, 0) + 1;
        }

        for (int i = 0; i < document.Length; i++) {
            var character = document[i];
            if (!charCounts.ContainsKey (character) || charCounts[character] == 0) {
                return false;
            }
            charCounts[character] = charCounts[character] - 1;
        }

        return true;
    }
}