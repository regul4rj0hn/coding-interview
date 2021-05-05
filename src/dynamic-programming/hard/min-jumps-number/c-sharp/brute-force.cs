using System;

// O(n^2) time | O(n) space
public class Program
{
    public static int MinNumberOfJumps(int[] array)
    {
        var jumps = new int[array.Length];
        Array.Fill(jumps, int.MaxValue);
        jumps[0] = 0;

        for (var i = 1; i < array.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (array[j] >= i - j)
                {
                    jumps[i] = Math.Min(jumps[j] + 1, jumps[i]);
                }
            }
        }

        return jumps[jumps.Length - 1];
    }
}
