using System;

/*
For each element on the document string, search for the value on the characters input string.
If it exists remove it, and continue looping through the document, otherwise just return false.
This solution is clean and compact but the performance is bad as IndexOf() is O(m) time complexity.

Time : O(n.m) - Where N is the length of the document string, and M the length of the chars string
Space: O(1)   - Checks are performed in-place without any extra structures
*/
public class Program {
    public bool GenerateDocument (string characters, string document) {
        for (int i = 0; i < document.Length; i++) {
            var index = characters.IndexOf (document[i]);
            if (characters.Length == 0 || index == -1) {
                return false;
            }
            characters = characters.Substring (0, index) + characters.Substring (index + 1);
        }
        return true;
    }
}