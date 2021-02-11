using System;

/*
Time : O(n) - Where N is the length of the input string
Space: O(n) - For the output string that will be of the same length N as the input
*/
public class Program {
    public static string CaesarCypherEncryptor (string str, int key) {
        string output = string.Empty;
        foreach (char ch in str) {
            output += Cipher (ch, key);
        }
        return output;
    }

    private static char Cipher (char ch, int key) {
        if (!char.IsLetter (ch)) {
            return ch;
        }
        char d = char.IsUpper (ch) ? 'A' : 'a';
        return (char) ((((ch + key) - d) % 26) + d);
    }
}