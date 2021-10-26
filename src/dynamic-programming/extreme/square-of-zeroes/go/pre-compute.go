package main

// O(n^3) time | O(n^2) space - where N is the height and width of the matrix
func SquareOfZeroes(matrix [][]int) bool {
	infoMatrix := preComputeNumOfZeroes(matrix)
	n := len(matrix)
	for topRow := 0; topRow < n; topRow++ {
		for leftCol := 0; leftCol < n; leftCol++ {
			squareLen := 2
			for squareLen <= n-leftCol && squareLen <= n-topRow {
				bottomRow := topRow + squareLen - 1
				rightCol := leftCol + squareLen - 1
				if isSquareOfZeroes(infoMatrix, topRow, leftCol, bottomRow, rightCol) {
					return true
				}
				squareLen += 1
			}
		}
	}
	return false
}

type InfoEntry struct {
	NumZeroesRight int
	NumZeroesBelow int
}

// r1 is the top row, c1 is the left-most column
// r2 is the bottom row, c2 is the right-most column
func isSquareOfZeroes(infoMatrix [][]InfoEntry, r1, c1, r2, c2 int) bool {
	squareLen := c2 - c1 + 1
	hasTopBorder := infoMatrix[r1][c1].NumZeroesRight >= squareLen
	hasLeftBorder := infoMatrix[r1][c1].NumZeroesBelow >= squareLen
	hasBottomBorder := infoMatrix[r2][c1].NumZeroesRight >= squareLen
	hasRightBorder := infoMatrix[r1][c2].NumZeroesBelow >= squareLen
	return hasTopBorder && hasLeftBorder && hasBottomBorder && hasRightBorder
}

func preComputeNumOfZeroes(matrix [][]int) [][]InfoEntry {
	infoMatrix := make([][]InfoEntry, len(matrix))
	for i, row := range matrix {
		infoMatrix[i] = make([]InfoEntry, len(row))
	}

	n := len(matrix)
	for row := 0; row < n; row++ {
		for col := 0; col < n; col++ {
			numZeroes := 0
			if matrix[row][col] == 0 {
				numZeroes = 1
			}
			infoMatrix[row][col] = InfoEntry{
				NumZeroesBelow: numZeroes,
				NumZeroesRight: numZeroes,
			}
		}
	}

	lastIdx := len(matrix) - 1
	for row := n - 1; row >= 0; row-- {
		for col := n - 1; col >= 0; col-- {
			if matrix[row][col] == 1 {
				continue
			}
			if row < lastIdx {
				infoMatrix[row][col].NumZeroesBelow += infoMatrix[row+1][col].NumZeroesBelow
			}
			if col < lastIdx {
				infoMatrix[row][col].NumZeroesRight += infoMatrix[row][col+1].NumZeroesRight
			}
		}
	}
	return infoMatrix
}
