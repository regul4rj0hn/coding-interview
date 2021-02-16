using System;

/*
The general approach is to build an array with the number of ways you can make change for all amounts between 0 and our target N, considering there is only one way to make change for 0 (to not use any coins).

Build up the ways to make change array one coin denomination at a time, adding the previous number of ways to make change for the current amount/index. Do so for all amounts between 0 and n using only one coin denomination, then combining two denominations, and so forth until you use all input denominations (thus, you counted all the ways to make change).

When the current coin denomination is strictly bigger than the target amount, there's nothing to do (can't break coins/bills appart).

Since we are adding up the ways to make change bottom-up, the way to make change for the final amount will be in our change array on the N position (ways[n])

Time : O(n.d) - Where N is the target number to make chage for and D is the amount distinct input coin denominations
Space: O(n)   - To store the maximum sums on each iteration
*/
public class Program {
    public static int NumberOfWaysToMakeChange (int n, int[] denoms) {
        int[] ways = new int[n + 1];
        ways[0] = 1;

        foreach (int coin in denoms) {
            for (int amount = 1; amount < n + 1; amount++) {
                if (coin <= amount) {
                    ways[amount] += ways[amount - coin];
                }
            }
        }

        return ways[n];
    }
}