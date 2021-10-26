package main

// O(n^4) time | O(1) space - where N is the height and width of the matrix
func SquareOfZeroes(matrix [][]int) bool {
	n := len(matrix)
	for topRow := 0; topRow < n; topRow++ {
		for leftCol := 0; leftCol < n; leftCol++ {
			squareLen := 2
			for squareLen <= n-leftCol && squareLen <= n-topRow {
				bottomRow := topRow + squareLen - 1
				rightCol := leftCol + squareLen - 1
				if isSquareOfZeroes(matrix, topRow, leftCol, bottomRow, rightCol) {
					return true
				}
				squareLen += 1
			}
		}
	}
	return false
}

// r1 is the top row, c1 is the left-most column
// r2 is the bottom row, c2 is the right-most column
func isSquareOfZeroes(matrix [][]int, r1, c1, r2, c2 int) bool {
	for row := r1; row < r2+1; row++ {
		if matrix[row][c1] != 0 || matrix[row][c2] != 0 {
			return false
		}
	}
	for col := c1; col < c2+1; col++ {
		if matrix[r1][col] != 0 || matrix[r2][col] != 0 {
			return false
		}
	}
	return true
}
