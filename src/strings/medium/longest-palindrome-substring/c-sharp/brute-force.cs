using System;

/*
Basic approach is to generate all possible substrings of the input string and check for their palindromicity. 

Time : O(n^3) - Where N is the length of the input string (2 nested for-loops plus the inner sub-string palindrome check)
Space: O(n)   - Worst case for the output string
*/
public class Program {
    public static string LongestPalindromicSubstring (string str) {
        var output = string.Empty;
        for (int i = 0; i < str.Length; i++) {
            for (int j = i; j < str.Length; j++) {
                string sub = str.Substring (i, j + 1 - i);
                output = sub.Length > output.Length && IsPalindrome (sub) ? sub : output;
            }
        }

        return output;
    }

    private static bool IsPalindrome (string str) {
        int last = str.Length - 1;
        for (int i = 0; i < str.Length; i++) {
            if (str[i] != str[last - i]) {
                return false;
            }
        }
        return true;
    }
}