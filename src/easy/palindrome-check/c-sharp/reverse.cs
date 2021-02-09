using System;

/*
Time : O(n^2) - Where N is the length of the string, if the first and the last don't match it just exits
Space: O(n)   - The space for the reverse string in both cases
*/
public class Program {
    public static bool IsPalindrome (string str) {
        return str.Equals (ReverseTwo (str));
    }

    public static string Reverse (string s) {
        char[] charArray = s.ToCharArray ();
        Array.Reverse (charArray);
        return new string (charArray);
    }

    public static string ReverseTwo (string s) {
        string reverse = string.Empty;
        for (int i = s.Length - 1; i >= 0; i--) {
            reverse += s[i];
        }
        return reverse;
    }
}