using System;
using System.Collections.Generic;

/*
To approach the solution we first find and store in a separate matrix the positions of all the non-island 1s. We can do so by performing a depth-first search traversal on all the 1s that are on the border of the image.
Afterwards, we can easily identify and remove all the island 1s from the input matrix by relying on the data structure that you used to store the positions of non-island 1s.

Time : O(wh) - Where W is the width and H is the height of the input matrix
Space: O(wh) - To store our "exploration" matrix
*/
public class Program
{
    public int[][] RemoveIslands (int[][] matrix)
    {
        var notIslands = new bool[matrix.Length, matrix[0].Length];

        // Find all the 1s (land) that are not islands
        for (var row = 0; row < matrix.Length; row++)
        {
            for (var col = 0; col < matrix[row].Length; col++)
            {
                var rowIsCoast = row == 0 || row == matrix.Length - 1;
                var colIsCoast = col == 0 || col == matrix[row].Length - 1;
                var isCoast = rowIsCoast || colIsCoast;

                if (!isCoast)
                {
                    continue;
                }
                if (matrix[row][col] != 1)
                {
                    continue;
                }

                FindNonIslands (matrix, row, col, notIslands);
            }
        }

        // Nuke islands
        for (var row = 1; row < matrix.Length - 1; row++)
        {
            for (var col = 1; col < matrix[row].Length - 1; col++)
            {
                if (notIslands[row, col])
                {
                    continue;
                }
                matrix[row][col] = 0;
            }
        }

        return matrix;
    }

    private static void FindNonIslands (int[][] matrix, int startRow, int startCol, bool[,] notIslands)
    {
        var stack = new Stack<Tuple<int, int>>();
        stack.Push(new Tuple<int, int> (startRow, startCol));

        while (stack.Count > 0)
        {
            var position = stack.Pop();
            var row = position.Item1;
            var col = position.Item2;

            var visited = notIslands[row, col];
            if (visited)
            {
                continue;
            }

            notIslands[row, col] = true;

            var neighbors = GetNeighbors (matrix, row, col);
            foreach (var cell in neighbors)
            {
                var currentRow = cell.Item1;
                var currentCol = cell.Item2;

                if (matrix[currentRow][currentCol] != 1)
                {
                    continue;
                }
                stack.Push(cell);
            }
        }
    }

    private static List<Tuple<int, int>> GetNeighbors (int[][] matrix, int row, int col)
    {
        var numRows = matrix.Length;
        var numCols = matrix[row].Length;
        var neighbors = new List<Tuple<int, int>>();

        if (row - 1 >= 0)
        {
            neighbors.Add (new Tuple<int, int>(row - 1, col)); // UP
        }
        if (row + 1 < numRows)
        {
            neighbors.Add (new Tuple<int, int>(row + 1, col)); // DOWN
        }
        if (col - 1 >= 0)
        {
            neighbors.Add (new Tuple<int, int>(row, col - 1)); // LEFT
        }
        if (col + 1 < numCols)
        {
            neighbors.Add (new Tuple<int, int>(row, col + 1)); // RIGHT
        }

        return neighbors;
    }
}
