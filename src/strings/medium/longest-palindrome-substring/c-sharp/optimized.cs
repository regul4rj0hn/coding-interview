using System;

/*
Treat each possition/character of the input string as the center of a potential palindrome (optimizes execution time).
Consider that the center of a palindrome can either be a character (odd-length palindromes) or an empty string (even-length palindromes), so we need to check in-between each letter of the string as well.
Keeping the above in mind, check if the current center substring is a palindrome by expanding outwards from the center, making sure that the characters on both sides are indeed mirrored.
During the process we store and update the start and end index of the longest palindrome substring instead of storing the actual substrings (optimizes storage).

Time : O(n^2) - Where N is the length of the input string (we are travesing the string once, but checking if it is palindrome outwards on each iteration)
Space: O(n)   - Worst case for slincing the final output string
*/
public class Program {
    public static string LongestPalindromicSubstring (string str) {
        int[] outputIndex = { 0, 1 };
        for (int i = 1; i < str.Length; i++) {
            int[] odd = GetLongestPalindrome (str, i - 1, i + 1);
            int[] even = GetLongestPalindrome (str, i - 1, i);
            int[] currentIndex = odd[1] - odd[0] > even[1] - even[0] ? odd : even;
            outputIndex = outputIndex[1] - outputIndex[0] > currentIndex[1] - currentIndex[0] ? outputIndex : currentIndex;
        }
        return str.Substring (outputIndex[0], outputIndex[1] - outputIndex[0]);
    }

    // Returns an array containing the start and end position of the longest palindrome substring between the indexes passed by parameter
    private static int[] GetLongestPalindrome (string str, int left, int right) {
        while (left >= 0 && right < str.Length) {
            if (str[left] != str[right]) {
                break;
            }
            left--;
            right++;
        }
        return new int[] { left + 1, right };
    }
}