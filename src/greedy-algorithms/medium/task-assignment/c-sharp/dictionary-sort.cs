using System.Collections.Generic;
using System.Linq;
using System;

/*
Since the problem states that we have K workers and that there will always be 2k tasks, we don't need to keep track of the available workers for any solution, just of tasks that have been assigned.

The brute force approach would have a O(n^2) complexity as we would have to try every task duration pairs to find the optimal pairing. If instead we sort the tasks in ascending order and just pair the shortest-duration task with the longest-duration task that will lead to an optimal pairing (greedy choice), because the total longest duration will be the shortest duration that it can possibly have.

The issue with sorting the input list is that we first need to record the original task ordering (indexes), because the output list of tasks expects the index of the task, not its duration value. We can use a Dictionary for that. An additional consideration is that we need to remove the { index, duration } pair from the dictionary once that we've used it, to avoid pairing the tasks twice. 

Time : O(n.log(n)) - Where N is the length of the input list of tasks (needs to be sorted, assuming n.log(n) sort)
Space: O(n)        - For the output list with the task pairs
*/
public class Program {
    public List<List<int>> TaskAssignment (int k, List<int> tasks) {
        var output = new List<List<int>>();
        var map = new Dictionary<int, int>();

        for (int i = 0; i < tasks.Count; i++) {
            map.Add (i, tasks[i]);
        }
        
        var values = map.Values.ToList();
        values.Sort();

        for (int i = 0; i < values.Count / 2; i++) {
            var current = new List<int>();

            var firstKey = map.FirstOrDefault (x => x.Value == values[i]).Key;
            current.Add(firstKey);
            map.Remove (firstKey);
            var secondKey = map.FirstOrDefault (x => x.Value == values[tasks.Count - 1 - i]).Key;
            current.Add (secondKey);
            map.Remove (secondKey);

            output.Add (current);
        }

        return output;
    }
}
