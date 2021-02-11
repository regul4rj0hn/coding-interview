using System;

/*
Time : O(n) - Where N is the length of the input string
Space: O(n) - For the output string that will be of length N or shorter
*/
public class Program {
    public string RunLengthEncoding (string str) {
        string output = string.Empty;
        char current;
        char next;
        int count = 1;
        int index = 0;

        while (index < str.Length) {
            current = str[index];
            // ugly "null character" to avoid having a "last case" scenario to handle
            next = index + 1 < str.Length ? str[index + 1] : '\0';
            if (count < 9 && next != '\0' && current == next) {
                count++;
                index++;
                // I don't like this
                continue;
            }
            output += count;
            output += current;
            count = 1;
            index++;
        }
        return output;
    }
}