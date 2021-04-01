using System;

/*
Build a MIN array storing the minimum number of coins needed to make change for all amounts between 0 and N inclusive, where each index corresponds to coin denomination (0, 1, 2, 3, ..., N). 

We iterate through the denominations array checking if our current coin is less than or equal to our target (index) dollar value. If it is, then we substract it to our target value (using the coin to reach the amount) and we use the resulting value to look up on our MIN array our previous minimum number of coins for that value. 

If the amount of coins we came up with is lower than the current value stored at that index, we update it. When we are done checking the denominations the solution will be stored in MIN[n] (or -1 if we can't make that amount).

Time : O(n.d) - Where N is the target number of coins and D is the number of elements in the denomos array
Space: O(n)   - Where N is the target number of coins (for the min number of coins array)
*/
public class Program {
    public static int MinNumberOfCoinsForChange(int n, int[] denoms) {
        var compare = 0;
        var coins = new int[n + 1];
        Array.Fill(coins, int.MaxValue);
        coins[0] = 0;

        foreach (var coin in denoms) {
            for (var amount = 0; amount < coins.Length; amount++) {
                if (coin <= amount) {
                    if (coins[amount - coin] == int.MaxValue) {
                        compare = coins[amount - coin];
                    }
                    else {
                        compare = coins[amount - coin] + 1;
                    }
                    coins[amount] = Math.Min (coins[amount], compare);
                }
            }
        }
        return coins[n] != int.MaxValue ? coins[n] : -1;
    }
}
