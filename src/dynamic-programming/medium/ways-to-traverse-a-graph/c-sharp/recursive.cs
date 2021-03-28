using System;

/*
Since we can only travel down and right from the top left, the number of ways we can traverse the graph to reach any position is equal to the number of ways to reach the position directly above it plus the number of ways to reach the position directly to its left. 

The recursive aproach makes sense and it is easy to implement, but the time and space complexity are horrible.

Time : O(2^(n+m)) - Where N is the width and M is the height of the graph
Space: O(n+m)     - For the recursive call stack frames
*/
public class Program {
    public int NumberOfWaysToTraverseGraph (int width, int height) {
        if (width == 1 || height == 1) {
            return 1;
        }

        return NumberOfWaysToTraverseGraph (width - 1, height) +
            NumberOfWaysToTraverseGraph (width, height - 1);
    }
}
