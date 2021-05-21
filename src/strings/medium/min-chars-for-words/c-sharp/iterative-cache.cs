using System;
using System.Linq;
using System.Collections.Generic;

/*
The key to solve the problem is realizing that a word can have more than one of the same character, so we'll need to count them and factor that in when generating the output array.

To approach the solution we use a hash table to keep track of the maximum frequencies of all unique characters that occur across all words. We count the frequency of each character in each word, and use those per-word frequencies to update the overall character chache.

Once we've determined the maximum frequency of each character across all words, we use the built-up cache to generate the output array.

Time : O(n.l) - Where N is the number of words and L is the length of the longest word
Space: O(c)   - Where C is the number of unique characters across all words
*/
public class Program
{
    public string[] MinimumCharactersForWords(string[] words)
    {
        var charsCache = new Dictionary<string, int>();

        foreach (var word in words)
        {
            var wordCache = CacheWordCharsFrequency(word);
            UpdateMaxCharAmount(wordCache, charsCache);
        }

        return MapCharCacheToArray(charsCache);
    }

    private Dictionary<char, int> CacheWordCharsFrequency(string word)
    {
        var wordCache = new Dictionary<char, int>();
        foreach (var letter in word)
        {
            if (!wordCache.ContainsKey(letter))
            {
                wordCache.Add(letter, 0);
            }
            wordCache[letter] += 1;
        }
        return wordCache;
    }

    private void UpdateMaxCharAmount(Dictionary<char, int> wordCache, Dictionary<string, int> charsCache)
    {
        foreach (var entry in wordCache)
        {
            var key = entry.Key.ToString();
            var val = entry.Value;
            if (!charsCache.ContainsKey(key))
            {
                charsCache.Add(key, val);
            }
            charsCache[key] = Math.Max(charsCache[key], val);
        }
    }

    private string[] MapCharCacheToArray(Dictionary<string, int> charsCache)
    {
        var output = new List<string>();
        foreach (var entry in charsCache)
        {
            for (var i = 0; i < entry.Value; i++)
            {
                output.Add(entry.Key);
            }
        }
        return output.ToArray();
    }
}
