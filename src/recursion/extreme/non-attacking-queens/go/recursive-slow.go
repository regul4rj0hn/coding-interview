package main

// Lower bound: O(n!) time | O(n) space - where N is the input number
// Each index of `columnPlacements` represents a row of the chessboard,
// and the value at each index is the column on the relevant row where
// a queen is currently placed
func NonAttackingQueens(n int) int {
	columnPlacements := make([]int, n)
	return getQueenPlacements(0, columnPlacements, n)
}

// Gets the number of non-attacking queen placements on the board
func getQueenPlacements(row int, colPlacement []int, boardSize int) int {
	if row == boardSize {
		return 1
	}
	validPlacements := 0
	for col := 0; col < boardSize; col++ {
		if isNonAttackingPlacement(row, col, colPlacement) {
			colPlacement[row] = col
			validPlacements += getQueenPlacements(row+1, colPlacement, boardSize)
		}
	}
	return validPlacements
}

// As `row` tends to `n` this becomes an O(n) time operation
func isNonAttackingPlacement(row, col int, colPlacement []int) bool {
	for previousRow := 0; previousRow < row; previousRow++ {
		columnToCheck := colPlacement[previousRow]
		sameColumn := columnToCheck == col
		onDiagonal := abs(columnToCheck-col) == row-previousRow
		if sameColumn || onDiagonal {
			return false
		}
	}
	return true
}

func abs(a int) int {
	if a < 0 {
		return -a
	}
	return a
}
