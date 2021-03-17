using System;
using System.Collections.Generic;

/*
Treat the matrix as a graph, where each node has a value and a list of four adjacent neighbor nodes (diagonals are not considered a river).
Traverse the matrix and whenever a node that's a part of a river (value 1) and hasn't been visited is found, we us DFS to explore that node's valid neighboring nodes to follow that river stream and determine its length.
To keep track of which nodes we've already visited and avoid doing needless expensive searches on visited nodes, we use a boolean matrix of the size of our input matrix and mark nodes as visited as we traverse them. 

Time : O(w.h) - Where W is the width of the matrix and H height of the matrix (since we are marking nodes as visited we never explore a node twice, checking visited is done constant time)
Space: O(w.h) - To store the visited nodes matrix (the solution list cannot be bigger than the input matrix itself)
*/
public class Program {
    public static List<int> RiverSizes (int[,] matrix) {
        var output = new List<int>();
        var visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); i++) {
            for (int j = 0; j < matrix.GetLength(1); j++) {
                if (!visited[i, j]) {
                    TraverseNode (i, j, matrix, visited, output);
                }
            }
        }

        return output;
    }

    private static void TraverseNode (int row, int col, int[,] matrix, bool[,] visited, List<int> output) {
        var currentLength = 0;
        var nodesToExplore = new Stack<int[]>();
        nodesToExplore.Push (new int[] { row, col });

        while (nodesToExplore.Count != 0) {
            var currentNode = nodesToExplore.Pop ();
            row = currentNode[0];
            col = currentNode[1];

            if (visited[row, col]) {
                continue;
            }

            visited[row, col] = true;

            if (matrix[row, col] == 0) {
                continue;
            }

            currentLength++;
            var unvisitedNeighbors = GetUnvisitedNeighbors (row, col, matrix, visited);
            foreach (var neighbor in unvisitedNeighbors) {
                nodesToExplore.Push (neighbor);
            }
        }

        if (currentLength > 0) {
            output.Add (currentLength);
        }
    }

    private static List<int[]> GetUnvisitedNeighbors (int row, int col, int[,] matrix, bool[,] visited) {
        var unvisited = new List<int[]>();

        if (row > 0 && !visited[row - 1, col]) {
            unvisited.Add (new int[] { row - 1, col });
        }
        if (row < matrix.GetLength(0) - 1 && !visited[row + 1, col]) {
            unvisited.Add (new int[] { row + 1, col});
        }
        if (col > 0 && !visited[row, col - 1]) {
            unvisited.Add (new int[] { row, col - 1 });
        }
        if (col < matrix.GetLength(1) - 1 && !visited[row, col + 1]) {
            unvisited.Add (new int[] { row, col + 1});
        }

        return unvisited;
    }
}
