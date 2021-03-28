using System;

/*
This is the smartass way as it uses a math formula with the number of permutations that can be done on a given set. E.g. in a 3 height * 4 width matrix, we'd need to go at least 3 times right and 2 times down to reach the end square no matter what path we take (height - 1 and width -1 respectively), so our set looks like this: { R, R, R, D, D }.

We use factorial with the distance from the the starting point to the end point (X movements down, Y movements right) to calculate the permutations:
                 (X + Y)!
Number of ways = ---------
                 (X)!*(Y)!

On top of that, we use a static array to store all the valid factorial results for 32bit integers, so we can retrieve those in constant time - as opposed to calculating it each time.

Time : O(1) - The input does not matter, we are performing all constant times operations
Space: O(1) - No extra space (the factorial array is constant and independent of the input)
*/
public class Program
{
    private static int[] Factors = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600 };

    public int NumberOfWaysToTraverseGraph(int width, int height)
    {
        var xDistance = width - 1;
        var yDistance = height - 1;

        var numerator = Factorial(xDistance + yDistance);
        var denominator = Factorial(xDistance) * Factorial(yDistance);

        return numerator / denominator;
    }

    private int Factorial(int n)
    {
        return Factors[n];
    }
}
