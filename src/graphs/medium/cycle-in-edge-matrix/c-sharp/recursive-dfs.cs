using System;

/*
To find back edges or cycles, we'll need to keep track of which nodes we've already visited and which nodes are ancestors of the current node in a depth-first-search tree way.

There are a few ways to do this, but one approach is to recursively traverse the graph while we keep track of which nodes have been visited in general and which nodes have been visited in the current recursion stack; which we can do with two separate data structures. 

When we reach a node that has an edge to a node that's already in the recursion stack, then we've detected a back edge, and there's a cycle in the graph.

Time : O(v+e) - Where V is the number of vertices and E is the number of edges in the graph
Space: O(v)   - To store the visited array of nodes and for the recursive call stack frames
*/
public class Program {
    public bool CycleInGraph(int[][] edges) {
        var countNodes = edges.Length;
        var visited = new bool[countNodes];
        var stacked = new bool[countNodes];
        
        for (var node = 0; node < countNodes; node++) {
            if (visited[node]) {
                continue;
            }
            var hasCycle = IsNodeInCycle (node, edges, visited, stacked);
            if (hasCycle) {
                return true;
            }
        }

        return false;
    }
    
    private bool IsNodeInCycle (int node, int[][] edges, bool[] visited, bool[] stacked) {
        visited[node] = true;
        stacked[node] = true;
        var hasCycle = false;
        var neighbors = edges[node];

        foreach (var neighbor in neighbors) {
            if (!visited[neighbor]) {
                hasCycle = IsNodeInCycle (neighbor, edges, visited, stacked);
            }
            if (hasCycle) {
                return true;
            }
            if (stacked[neighbor]) {
                return true;
            }
        }

        stacked[node] = false;
        return false;
    }
}
