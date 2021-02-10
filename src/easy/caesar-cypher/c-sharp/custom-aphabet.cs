using System;

/*
Similar solution but you can define the alphabet (insted of using ASCII codes)
Time : O(n) - Where N is the length of the input string
Space: O(n) - For the output string that will be of the same length N as the input
*/
public class Program {
    public static string CaesarCypherEncryptor (string str, int key) {
        string output = string.Empty;
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        foreach (char c in str) {
            output += Cypher (c, key, alphabet);
        }
        return output;
    }

    private static char Cypher (char c, int key, string alphabet) {
        int code = alphabet.IndexOf (c) + key % 26;
        return alphabet[code % 26];
    }
}