using System;

/*
This approach is similar to the recursive depth first search approach and has the same time and space complexity, but it's a different way to detect a back edge: performing a 3-color depth-first search. 

Each node is colored white to start. As we recursively traverse through the graph, we color the current node grey and then call the recursive traversal function on all of its neighbors. After traversing all the neighbors, we color the original current node black to signify that it's "done" (no loops). 

As soon as we find an edge to a node that's colored grey, we've found a back edge thus there's a cycle in the graph.

Time : O(v+e) - Where V is the number of vertices and E is the number of edges in the graph
Space: O(v)   - To store the colors array and for the recursive call stack frames
*/
public class Program
{
    // Unvisited Node
    private const int White = 0;
    // Being Processed (recursive stack) Node
    private const int Gray = 1;
    // Finished Node
    private const int Black = 3;

    public bool CycleInGraph (int[][] edges)
    {
        var countNodes = edges.Length;
        var colors = new int[countNodes];
        Array.Fill(colors, White);

        for (var node = 0; node < countNodes; node++)
        {
            if (colors[node] != White)
            {
                continue;
            }
            var hasCycle = TraverseAndColorCode (node, edges, colors);
            if (hasCycle)
            {
                return true;
            }
        }

        return false;
    }

    private bool TraverseAndColorCode (int node, int[][] edges, int[] colors)
    {
        colors[node] = Gray;
        var neighbors = edges[node];

        foreach (var neighbor in neighbors)
        {
            var neighborColor = colors[neighbor];

            if (neighborColor == Gray)
            {
                return true;
            }
            if (neighborColor == Black)
            {
                continue;
            }
            var hasCycle = TraverseAndColorCode (neighbor, edges, colors);
            if (hasCycle)
            {
                return true;
            }
        }

        colors[node] = Black;
        return false;
    }
}
