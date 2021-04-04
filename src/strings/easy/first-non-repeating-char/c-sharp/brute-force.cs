using System;

/*
The brute-force approach is simple, just start traversing the string from the beginning and compare each character with each of the other characters in the string.

As soon as we find the first character that doesn't have any duplicates (made it to the end of the strings without finding duplicates) we return it. 

Time : O(n^2) - Where N is the length of the input string
Space: O(1)   - No additional data structures
*/
public class Program {
    public int FirstNonRepeatingCharacter(string str) {
        for (var i = 0; i < str.Length; i++) {
            var hasDups = false;
            for (var j = 0; j < str.Length; j++) {
                if (str[i] == str[j] && i != j) {
                    hasDups = true;
                }
            }
            if (!hasDups) {
                return i;
            }
        }

        return -1;
    }
}
