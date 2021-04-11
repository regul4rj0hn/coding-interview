using System;
using System.Collections.Generic;

/*
This problem can also be solved without the use of a data structure that stores the positions of non-islands 1s. 

Simply loop through the border of the image, and perform a depth-first search on all positions with the value 1. During this depth-first search, find all the 1s that are connected to the original position on the border, and change them from 1 to 2. After changing all non-island 1s to 2s, we can simply remove all the remaining 1s, which are guaranteed to be islands, from the matrix (by replacing them with 0s), and change all the 2s back to 1s, since these were previously determined to be non-islands.

Time : O(wh) - Where W is the width and H is the height of the input matrix
Space: O(1)  - We don't store additional data
*/
public class Program
{
    public int[][] RemoveIslands (int[][] matrix)
    {
        // Mark all the land that's not an island with a 2
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

                MarkNotIslands (matrix, row, col);
            }
        }

        // Nuke the remaining 1s and change marked 2s (non-island) back to 1 (land)
        for (var row = 0; row < matrix.Length; row++)
        {
            for (var col = 0; col < matrix[row].Length; col++)
            {
                var check = matrix[row][col];
                if (check == 1)
                {
                    matrix[row][col] = 0;
                }
                if (check == 2)
                {
                    matrix[row][col] = 1;
                }
            }
        }

        return matrix;
    }

    private static void MarkNotIslands (int[][] matrix, int startRow, int startCol)
    {
        var stack = new Stack<Tuple<int, int>>();
        stack.Push(new Tuple<int, int>(startRow, startCol));

        while (stack.Count > 0)
        {
            var position = stack.Pop();
            var row = position.Item1;
            var col = position.Item2;

            matrix[row][col] = 2;

            var neighbors = GetNeighbors (matrix, row, col);
            foreach (var cell in neighbors)
            {
                var currentRow = cell.Item1;
                var currentCol = cell.Item2;

                if (matrix[currentRow][currentCol] != 1)
                {
                    continue;
                }
                stack.Push (cell);
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