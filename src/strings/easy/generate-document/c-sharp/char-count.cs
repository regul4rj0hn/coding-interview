using System;

/*
For each element on the document string, count how many times it occurs in the input chars and document strings. If the char count from the document input is bigger than that of the characters string, then we can't generate the document with the given input and we return false.
This is a different take on the brute-force solution, but it's still pretty bad in time complexity.

Time : O(n.(n + m)) - Where N is the length of the document string, and M the length of the chars string
Space: O(1)         - Checks are performed in-place without any extra structures
*/
public class Program {
    public bool GenerateDocument (string characters, string document) {
        for (int i = 0; i < document.Length; i++) {
            var character = document[i];
            var docFrequency = CountCharFrequency (character, document);
            var charFrequency = CountCharFrequency (character, characters);

            if (docFrequency > charFrequency) {
                return false;
            }
        }
        return true;
    }

    private int CountCharFrequency (char character, string str) {
        var frequency = 0;
        for (int i = 0; i < str.Length; i++) {
            var current = str[i];
            frequency = current == character ? frequency + 1 : frequency;
        }
        return frequency;
    }
}