using System;

/*
Since our main "formula" to calculate the minimum number of edits in the previous approach only used the current row and the row above it, we can optimize the space complexity by just storing these two rows to arrive to our solution.
The space complexity will be the minimum length between our two input strings, as we can pick which one we are using as the rows and the columns, we want the shortest one to be our columns. 

Time : O(n.m)      - Where N is the length of the str1 input and M is the length of str2 input string
Space: O(min(n,m)) - We store an array of the shortest length between str1 and str2 to track our edits
*/
public class Program
{
    public static int LevenshteinDistance (string str1, string str2)
    {
        var shorter = str1.Length < str2.Length ? str1 : str2;
        var longer = str1.Length >= str2.Length ? str1 : str2;

        var evenEdits = new int[shorter.Length + 1];
        var oddEdits = new int[shorter.Length + 1];

        for (var i = 0; i < shorter.Length + 1; i++)
        {
            evenEdits[i] = i;
        }

        int[] currentEdits;
        int[] previousEdits;

        for (var i = 1; i < longer.Length + 1; i++)
        {
            if (i % 2 == 1)
            {
                currentEdits = oddEdits;
                previousEdits = evenEdits;
            }
            else
            {
                currentEdits = evenEdits;
                previousEdits = oddEdits;
            }
            currentEdits[0] = i;
            for (var j = 1; j < shorter.Length + 1; j++)
            {
                if (longer[i - 1] == shorter[j - 1])
                {
                    currentEdits[j] = previousEdits[j - 1];
                }
                else
                {
                    currentEdits[j] = 1 + Math.Min (previousEdits[j - 1], Math.Min (previousEdits[j], currentEdits[j - 1]));
                }
            }
        }

        return longer.Length % 2 == 0 ? evenEdits[shorter.Length] : oddEdits[shorter.Length];
    }
}
