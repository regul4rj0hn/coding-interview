using System;

/*
The base case is when the height is equal to 0 or 1, because we know that no matter what the maxSteps values is there's only going to be one way to get to step 0 or 1.
For the recursive step, the number of ways to climb a staircase of height `k` with a max number of steps `s` is: `numWays[k - 1] + numWays[k - 2] + ... + numWays[k - s]`.
This is because if you can advance between `1` and `s` steps, then from each step `k - 1, k - 2, ..., k - s`, you can directly advance to the top of a staircase of height `k`.

By adding the number of ways to reach all steps from which you can directly advance to the top, you determine how many ways there are to reach the top step.

In code that looks like a for loop from 1 to k with a recursive call inside, which results in a horrible time complexity.

Time : O(k^n) - Where N is the the height of the staircase (and tree of recursive calls) and K is the number of max steps
Space: O(n)   - For the frames of the recursive call stack (depht of the recursive call tree)
*/
public class Program {
    public int StaircaseTraversal (int height, int maxSteps) {
        if (height <= 1) {
            return 1;
        }

        var ways = 0;
        for (var step = 1; step < Math.Min (maxSteps, height) + 1; step++) {
            ways += StaircaseTraversal (height - step, maxSteps);
        }

        return ways;
    }
}
