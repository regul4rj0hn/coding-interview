using System;

/*
A different approach with the same time and space complexity is to start by reversing the entire string.
Once the entire string has been reversed, the words will be in the correct order, but each word will also be reversed.
From here, just reverse all of the individual words in this new string and that will be our desired output.

Time : O(n) - Where N is the length of the input string
Space: O(n) - For the list data structure to reverse
*/
public class Program
{
    public string ReverseWordsInString (string str)
    {
        var characters = str.ToCharArray();
        var wordStart = 0;
        ReverseListRange (characters, wordStart, characters.Length - 1);

        while (wordStart < characters.Length)
        {
            var wordEnd = wordStart;
            while (wordEnd < characters.Length && characters[wordEnd] != ' ')
            {
                wordEnd++;
            }

            ReverseListRange (characters, wordStart, wordEnd - 1);
            wordStart = wordEnd + 1;
        }

        return new string(characters);
    }

    private char[] ReverseListRange (char[] list, int start, int end)
    {
        while (start < end)
        {
            var tmp = list[start];
            list[start] = list[end];
            list[end] = tmp;
            start++;
            end--;
        }

        return list;
    }
}
