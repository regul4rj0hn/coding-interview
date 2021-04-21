using System;
using System.Collections.Generic;

/*
Build a two-dimensional array of the maximum values that knapsacks of all capacities between 0 and our input capacity inclusive could hold, given one, two, three.. N items. Let columns represent capacities and rows represent items.
Let our "values" array, the rows "i" and columns "j", the weight "w" and value "v", the dynamic programming formula that relates the maximum value at any given point to previous values/prices accumulated, shrinking down the problem, is as follows:

values[i][j] = Max (values[i - 1][j], values[i-1][j - w] + v)

It takes into account the two possibilities for maximizing the value of our knapsack: 
 + The item doesn't fit (item weight greater than current capacity), so we just take the value of the row right above the current one: values[i-1][capacity]
 + The item fits, so we take the maximum value between:
    - NOT adding the current item into the backpack, so our current value will be the exact same as that of the row right above our position [i - 1]
    - ADDing the curent item into the bag, so we sum the value recorded on the previous row _minus_ the weight of our current item [i-1, j-w], plus the value of the current item (v).

When we are done building the array, we backtrack our way through it to find which items are in our knapsack. Start at the final index in the array and check whether or not the value stored at that index is equal to the value located one row above. If it isn't, then the item represented by the current row is in the knapsack. That's the list of items<value, weight> that we are going to return.

Time : O(n.c) - Where N is the number of items in the item matrix and C is the input capacity
Space: O(n.c) - To store the knapsack and the return sequence
*/
public class Program {
    public static List<List<int> > KnapsackProblem(int[,] items, int capacity) {
        var knapsack = new int[items.GetLength(0) + 1, capacity + 1];

        for (var i = 1; i < items.GetLength(0) + 1; i++) {
            var weight = items[i-1, 1];
            var value = items[i-1, 0];

            for (var c = 0; c < capacity + 1; c++) {
                if (weight > c) {
                    knapsack[i, c] = knapsack[i-1, c];
                }
                else {
                    knapsack[i, c] = Math.Max (knapsack[i-1, c], knapsack[i-1, c-weight] + value);
                }
            }
        }
        return GetKnapsackItems (knapsack, items, knapsack[items.GetLength(0), capacity]);
    }

    private static List<List<int>> GetKnapsackItems (int[,] knapsack, int[,] items, int weight) {
        var i = knapsack.GetLength(0) - 1;
        var c = knapsack.GetLength(1) - 1;
        var sequence = new List<List<int>>();
        var weights = new List<int>();

        weights.Add(weight);
        sequence.Add(weights);
        sequence.Add(new List<int>());

        while (i > 0) {
            if (knapsack[i, c] == knapsack[i-1, c]) {
                i--;
            }
            else {
                sequence[1].Insert(0, i-1);
                c -= items[i-1, 1];
                i--;
            }
            if (c == 0) {
                break;
            }
        }

        return sequence;
    }
}
