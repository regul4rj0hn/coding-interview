using System;

/*
Time : O(n) - Where N is the length of the input string
Space: O(n) - For the output string that will be of length N or shorter
*/
public class Program {
    public string RunLengthEncoding (string str) {
        string output = string.Empty;
        int runLength = 1;

        for (int i = 1; i < str.Length; i++) {
            char current = str[i];
            char previous = str[i - 1];

            if (current != previous || runLength == 9) {
                output += runLength;
                output += previous;
                runLength = 0;
            }

            runLength++;
        }

        // Last run 
        output += runLength;
        output += str[str.Length - 1];

        return output;
    }
}