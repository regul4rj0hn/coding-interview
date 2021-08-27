package main

// Uper Bound: O(n!) time | O(n) space - where N is the input number
// This solution narrows down the problem by placing a queen, and blocking the positions
// (row, column and diagonals) that would lead to a board containing an attacking position
func NonAttackingQueens(n int) int {
	blockedColumns := map[int]bool{}
	blockedUpDiagonals := map[int]bool{}
	blockedDownDiagonals := map[int]bool{}
	return getQueenPlacements(0, blockedColumns, blockedUpDiagonals, blockedDownDiagonals, n)
}

func getQueenPlacements(row int, blockedCol, blockedUpDiag, blockedDownDiag map[int]bool, boardSize int) int {
	if row == boardSize {
		return 1
	}
	validPlacements := 0
	for col := 0; col < boardSize; col++ {
		if isNonAttackingPlacement(row, col, blockedCol, blockedUpDiag, blockedDownDiag) {
			placeQueen(row, col, blockedCol, blockedUpDiag, blockedDownDiag)
			validPlacements += getQueenPlacements(row+1, blockedCol, blockedUpDiag, blockedDownDiag, boardSize)
			removeQueen(row, col, blockedCol, blockedUpDiag, blockedDownDiag)
		}
	}
	return validPlacements
}

// always an O(1) time operation
func isNonAttackingPlacement(row, col int, blockedCol, blockedUpDiag, blockedDownDiag map[int]bool) bool {
	if blockedCol[col] {
		return false
	}
	if blockedUpDiag[row+col] {
		return false
	}
	if blockedDownDiag[row-col] {
		return false
	}
	return true
}

func placeQueen(row, col int, blockedCol, blockedUpDiag, blockedDownDiag map[int]bool) {
	blockedCol[col] = true
	blockedUpDiag[row+col] = true
	blockedDownDiag[row-col] = true
}

func removeQueen(row, col int, blockedCol, blockedUpDiag, blockedDownDiag map[int]bool) {
	blockedCol[col] = false
	blockedUpDiag[row+col] = false
	blockedDownDiag[row-col] = false
}
