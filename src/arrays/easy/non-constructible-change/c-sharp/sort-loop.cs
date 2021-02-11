using System;

/*
The brute-force approch for solving this problem is not only -horrible- in execution time, but also quite
hard to implement. We would have to consider each possible change from 1..k and start adding up the coins
on our input array until we hit one that we cannot construct.

In contrast, the algorithm below takes into account the fact that, after sorting the coins array, the min
amount of change can be calculated by progressively adding the coins in the input array (on minChange) and
cosidering whether the next coin is greater than the minChange+1 or not. If the next coin is smaller, then
that means that we can generate all the previous changes, plus the value of the next coin, so we can safely
add that coin to the minChange and continue. If on the other hand the next coin is greater than minChange,
that means that the previous minChange+1 is our target non-constructible change to return.

Trying a few example arrays and corner cases helps verify this simple algorithm.

Time : O(n.log(n)) - Where N is the number of coins on the array, and assuming an optimal sort algorithm
Space: O(1)        - Just two int registries for the left and right index, no extra space
*/
public class Program {
    public int NonConstructibleChange (int[] coins) {
        int minChange = 0;
        int index = 0;

        Array.Sort (coins);

        while (index < coins.Length && coins[index] <= minChange + 1) {
            minChange += coins[index];
            index++;
        }

        return minChange + 1;
    }
}