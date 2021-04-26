using System;

/*
To approach a solution we declare three variables i, j, and k, pointing to indices in the three strings, respectively, and starting at 0. 
At any given combination of indices, if neither the character at i in the first string nor the character at j in the second string is equal to the character at k in the third string, then it must mean the first two strings can't interweave to form the third one (following the problem's definition).
If instead at any given combination of the indices i, j, and k, the character at i in the first string or the character at j in the second string is equal to the character at k in the third string, then we can potentially interweave the first two strings to get the third one. In such a case, we increment the two relevant indices (i and k or j and k) and call recursively, repeating this process until we confirm whether or not the first two strings can be interwoven to form the third one.

Time : O(2^(n+m)) - Where N is the length of the first string and M is the length of the second string
Space: O(n + m)   - For the recursive call stack frames
*/
public class Program
{
    public static bool Interweavingstrings (string one, string two, string three)
    {
        if (three.Length != one.Length + two.Length)
        {
            return false;
        }
        return AreInterwoven (one, two, three, 0, 0);
    }

    private static bool AreInterwoven (string one, string two, string three, int i, int j)
    {
        var k = i + j;
        if (k == three.Length)
        {
            return true;
        }

        if (i < one.Length && one[i] == three[k])
        {
            if (AreInterwoven (one, two, three, i + 1, j))
            {
                return true;
            }
        }

        if (j < two.Length && two[j] == three[k])
        {
            return AreInterwoven (one, two, three, i, j + 1);
        }

        return false;
    }
}
