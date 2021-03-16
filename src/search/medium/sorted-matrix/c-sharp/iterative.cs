using System;

/*
This can be resolved by iterating through the whole matrix (brute force), but that would result in O(N*M) time complexity.

The trick is to start from the top right corner of the matrix, and make use of the fact that every row and column in the matrix is sorted in ascending order. 
By starting at the top right spot, we can repeatedly eliminate columns/rows where our target cannot possibly be:
 - If the number on the top right is bigger than our target number, then we can avoid searching that whole column as every number in there has to be even bigger, so we move left one column and search there.
 - If the number on our new position is smaller than our target, then it must mean that the number is not on that row as every other number has to be even smaller (the row is sorted), so we continue the search on the next row.
We repeat this process until we either find the target number and return our current row / column index position, or we get to the bottom left-most corner of the matrix which means the target is not in the matrix.

Time : O(n+m) - Where N is the number of columns and M is the number of rows (this is the worse case if the number is on the bottom left-most spot in the matrix)
Space: O(1)   - Search for the target in place on the input matrix
*/
public class Program
{
    public static int[] SearchInSortedMatrix(int[,] matrix, int target)
    {
        var row = 0;
        var col = matrix.GetLength(1) - 1;

        while (row < matrix.GetLength(0) && col >= 0)
        {
            if (matrix[row, col] > target)
            {
                col--;
            }
            else
            {
                if (matrix[row, col] < target)
                {
                    row++;
                }
                else
                {
                    return new int[] { row, col };
                }
            }
        }

        return new int[] { -1, -1 };
    }
}
