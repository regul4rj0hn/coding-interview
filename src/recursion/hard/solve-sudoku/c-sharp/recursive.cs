using System.Collections.Generic;
using System;

/*
The brute-force approach to this problem is to generate every possible Sudoku board and then check each one until we find one that's valid. The issue with the solution is that there are 9^81 possible 9x9 Sudoku boards, which makes it pretty horrible to even consider this approach.

Considering that a Sudoku board doesn't need to be entirely filled to figure out if it's invalid and won't lead to a solution, we can try generating partially filled Sudoku boards until they become invalid, abandoning solutions that will never lead to a properly solved board early. This is formally known as backtracking. 

We attempt to place digits into empty positions in the Sudoku board and check at each insertion if the newly inserted digit makes the Sudoku board invalid. If it does, then we try to insert another digit until we find one that doesn't invalidate the board. If it doesn't invalidate the board, we temporarily place that digit and continue to try to solve the rest of the board. When / if we ever reach a position where there are no valid digits to be inserted (every digit placed in that position leads to an invalid board), that means that one of the previously inserted digits is incorrect. Thus, we must backtrack and change previously placed digits.

Time : O(1) - Assuming a constant 9x9 input board, the time complexity will always be constant
Space: O(1) - Same as the time complexity analysis
*/
public class Program {
    public List<List<int> > SolveSudoku(List<List<int> > board) {
        SolvePartialSudoku (0, 0, board);
        return board;
    }

    // Solve the Sudoku board from top-left to right (filling the rows first and then the columns)
    private bool SolvePartialSudoku (int row, int col, List<List<int>> board) {
        var currentRow = row;
        var currentCol = col;

        // if we are at column 9, we've filled the current row so we need to move down
        if (currentCol == board[currentRow].Count) {
            currentRow += 1;
            currentCol = 0;
            // check if we got to the last row, if so we've solved the problem
            if (currentRow == board.Count) {
                return true;
            }
        }

        // if the current value is zero that means the position has not been filled in yet, so we try with the alternatives 1-9
        if (board[currentRow][currentCol] == 0) {
            return TryDigitsAtPosition (currentRow, currentCol, board);
        }

        // if we got hear it means that we can call recursively with the next position to the right
        return SolvePartialSudoku (currentRow, currentCol + 1, board);
    }

    // loops through the digits 1-9 for a position and either calls SolvePartialSudoku recursively or backtracks
    private bool TryDigitsAtPosition (int row, int col, List<List<int>> board) {
        for (var digit = 1; digit < 10; digit++) {
            // check if the digit attempt is valid at the current position in the current board state
            if (IsValidAtPosition (digit, row, col, board)) {
                board[row][col] = digit;
                if (SolvePartialSudoku (row, col + 1, board)) {
                    return true;
                }
            }
        }
        // if we went through all of the digits and the board turned out invalid, we set the current back to cero and backtrack
        board[row][col] = 0;
        return false;
    }

    // checks the row, column, and current grid to see whether an input digit is valid at its position in the current board state or not
    private bool IsValidAtPosition (int digit, int row, int col, List<List<int>> board) {
        var rowIsValid = !board[row].Contains(digit);
        var colIsValid = true;

        for (var r = 0; r < board.Count; r++) {
            if (board[r][col] == digit) {
                colIsValid = false;
            }
        }

        if (!rowIsValid || !colIsValid) {
            return false;
        }

        var subGridRowStart = (row / 3) * 3;
        var subGridColStart = (col / 3) * 3;
        for (var rowIdx = 0; rowIdx < 3; rowIdx++) {
            for (var colIdx = 0; colIdx < 3; colIdx++) {
                var checkRow = subGridRowStart + rowIdx;
                var checkCol = subGridColStart + colIdx;
                var currentDigit = board[checkRow][checkCol];
                
                if (currentDigit == digit) {
                    return false;
                }
            }
        }

        return true;
    }
}
