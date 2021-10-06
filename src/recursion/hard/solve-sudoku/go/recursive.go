package main

// O(1) time | O(1) space - assuming a 9x9 input board
func SolveSudoku(board [][]int) [][]int {
	solvePartialSudoku(0, 0, board)
	return board
}

func solvePartialSudoku(row, col int, board [][]int) bool {
	var currentRow = row
	var currentCol = col

	if currentCol == len(board[currentRow]) {
		currentRow += 1
		currentCol = 0
		if currentRow == len(board) {
			return true
		}
	}
	if board[currentRow][currentCol] == 0 {
		return tryDigitsAtPosition(currentRow, currentCol, board)
	}
	return solvePartialSudoku(currentRow, currentCol+1, board)
}

func tryDigitsAtPosition(row, col int, board [][]int) bool {
	for digit := 1; digit < 10; digit++ {
		if isValidPosition(digit, row, col, board) {
			board[row][col] = digit
			if solvePartialSudoku(row, col+1, board) {
				return true
			}
		}
	}
	board[row][col] = 0
	return false
}

func isValidPosition(value, row, col int, board [][]int) bool {
	rowIsValid := !rowContains(board, row, value)
	columnIsValid := !columnContains(board, col, value)
	if !rowIsValid || !columnIsValid {
		return false
	}

	subgridRowStart := (row / 3) * 3
	subgridColStart := (col / 3) * 3
	for rowIdx := 0; rowIdx < 3; rowIdx++ {
		for colIdx := 0; colIdx < 3; colIdx++ {
			rowToCheck := subgridRowStart + rowIdx
			colToCheck := subgridColStart + colIdx
			existingValue := board[rowToCheck][colToCheck]

			if existingValue == value {
				return false
			}
		}
	}
	return true
}

func rowContains(board [][]int, row, value int) bool {
	for _, element := range board[row] {
		if value == element {
			return true
		}
	}
	return false
}

func columnContains(board [][]int, col, value int) bool {
	for _, row := range board {
		if row[col] == value {
			return true
		}
	}
	return false
}
