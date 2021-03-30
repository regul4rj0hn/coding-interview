using System;
using System.Collections.Generic;

/*
Locate all of the words in the string and figure out how many spaces are between them.
Create a list that contains all of the words in the string and all of the spaces between them.
When we are done traversing the string just reverse the list, and recreate the string to return using the reversed list.

Time : O(n) - Where N is the length of the input string
Space: O(n) - For the list data structure to reverse
*/
public class Program
{
    public string ReverseWordsInString (string str)
    {
        var words = new List<string>();
        var wordStart = 0;

        for (var i = 0; i < str.Length; i++)
        {
            var character = str[i];

            if (character == ' ')
            {
                words.Add (str.Substring (wordStart, i - wordStart));
                wordStart = i;
            }
            else
            {
                if (str[wordStart] == ' ')
                {
                    words.Add (" ");
                    wordStart = i;
                }
            }
        }

        words.Add (str.Substring (wordStart));
        words.Reverse();

        return string.Join ("", words);
    }
}
