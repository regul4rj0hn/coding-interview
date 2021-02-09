using System;

/*
Time : O(n) - It's actually N/2 where N is the length of the string, if the first and the last don't match it just exits
Space: O(1) - Just two int registries for the left and right index, no extra space
*/
public class Program {
    public static bool IsPalindrome (string str) {
        bool isPalindrome = true;
        int index = 0;
        int current = str.Length - 1 - index;

        while (isPalindrome && index < current) {
            if (str[index] != str[current]) {
                isPalindrome = false;
            }
            index++;
            current = str.Length - 1 - index;
        }

        return isPalindrome;
    }
}