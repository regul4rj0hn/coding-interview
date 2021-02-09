using System;

/*
Time : O(n) - Where N is the length of the string, if the first and the last don't match it just exits
Space: O(n) - The when it's a palindrome the call stack can get to N/2 frames where N is the length of the string
*/
public class Program {
    public static bool IsPalindrome (string str) {
        return PalindromeHelper (str, 0, str.Length - 1);
    }

    public static bool PalindromeHelper (string str, int start, int end) {
        if (start >= end) {
            return true;
        }
        if (str[start] == str[end]) {
            return PalindromeHelper (str, start + 1, end - 1);
        }
        else {
            return false;
        }
    }
}