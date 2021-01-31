using System;
using System.Linq;

/*
Time:  O(n.log(n)) - assuming efficient sort
Space: O(1) - sort in place, no extra space
Greedy algorithm => shortest job first
*/
public class Program {
    public int MinimumWaitingTime (int[] queries) {
        // if you can't mutate the structure in place then:
        // int[] sjfQueries = queries.OrderBy (i => i).ToArray();
        Array.Sort(queries);
        int minWait = 0;
        int current = 0;

        for (int i = 0; i < queries.Length - 1; i++) {
            current += queries[i];
            minWait += current;
        }

        return minWait;
    }
}