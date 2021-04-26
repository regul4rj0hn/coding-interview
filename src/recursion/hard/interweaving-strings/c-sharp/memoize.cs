using System;

/*
Same as the recursive approach but incorporating a memoize to improve the time complexity avoiding recalculating the same thing multiple times.

Time : O(n.m) - Where N is the length of the first string and M is the length of the second string
Space: O(n.m)   - For the recursive call stack frames and the memoize / cache data structure
*/
public class Program {
    public static bool Interweavingstrings (string one, string two, string three) {
        if (three.Length != one.Length + two.Length) {
            return false;
        }

        var cache = new bool?[one.Length + 1, two.Length + 1];
        return AreInterwoven (one, two, three, 0, 0, cache);
    }

    private static bool AreInterwoven (string one, string two, string three, int i, int j, bool?[,] cache) {
        if (cache[i, j].HasValue) {
            return cache[i, j].Value;
        }

        var k = i + j;
        if (k == three.Length) {
            return true;
        }

        if (i < one.Length && one[i] == three[k]) {
            cache[i, j] = AreInterwoven (one, two, three, i + 1, j, cache);
            if (cache[i, j].HasValue && cache[i, j].Value) {
                return true;
            }
        }

        if (j < two.Length && two[j] == three[k]) {
            cache[i, j] = AreInterwoven (one, two, three, i, j + 1, cache);
            return cache[i, j].Value;
        }

        cache[i, j] = false;
        return false;
    }
}
