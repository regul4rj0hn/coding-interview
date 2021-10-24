package main

import (
	"math"
)

// O(w.h) time | O(w.h) space
// where W is the width and H is the height of the matrix
func MaximumSumSubmatrix(matrix [][]int, size int) int {
	sums := createSumMatrix(matrix)
	maxSubMatrixSum := math.MinInt32

	for row := size - 1; row < len(matrix); row++ {
		for col := size - 1; col < len(matrix[row]); col++ {
			total := sums[row][col]

			touchesTopBorder := row-size < 0
			if !touchesTopBorder {
				total -= sums[row-size][col]
			}

			touchesLeftBorder := col-size < 0
			if !touchesLeftBorder {
				total -= sums[row][col-size]
			}

			touchesTopOrLeft := touchesTopBorder || touchesLeftBorder
			if !touchesTopOrLeft {
				total += sums[row-size][col-size]
			}

			maxSubMatrixSum = max(maxSubMatrixSum, total)
		}
	}
	return maxSubMatrixSum
}

func createSumMatrix(matrix [][]int) [][]int {
	sums := make([][]int, len(matrix))
	for i := range sums {
		sums[i] = make([]int, len(matrix[0]))
	}
	sums[0][0] = matrix[0][0]
	// Fill first row
	for i := 1; i < len(matrix[0]); i++ {
		sums[0][i] = sums[0][i-1] + matrix[0][i]
	}
	// Fill first column
	for i := 1; i < len(matrix); i++ {
		sums[i][0] = sums[i-1][0] + matrix[i][0]
	}
	// Fill the rest
	for row := 1; row < len(matrix); row++ {
		for col := 1; col < len(matrix[row]); col++ {
			sums[row][col] = sums[row-1][col] + sums[row][col-1] - sums[row-1][col-1] + matrix[row][col]
		}
	}
	return sums
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
