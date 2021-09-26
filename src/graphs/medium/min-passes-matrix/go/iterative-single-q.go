package main

type IntPair struct {
	First, Second int
}

// O(w.h) time | O(w.h) space
// where W is the width of the matrix and H is the height
func MinimumPassesOfMatrix(matrix [][]int) int {
	passes := convertNegatives(matrix)
	if !containsNegative(matrix) {
		return passes - 1
	} else {
		return -1
	}
}

func convertNegatives(matrix [][]int) int {
	queue := getAllPositivePositions(matrix)

	var passes = 0
	for len(queue) > 0 {
		var currentSize = len(queue)
		for currentSize > 0 {
			nextElement := queue[0]
			queue = queue[1:]
			currentRow, currentCol := nextElement.First, nextElement.Second
			adjacentPositions := getAdjacentPositions(currentRow, currentCol, matrix)
			for _, position := range adjacentPositions {
				row, col := position.First, position.Second
				value := matrix[row][col]
				if value < 0 {
					matrix[row][col] *= -1
					queue = append(queue, IntPair{row, col})
				}
			}
			currentSize -= 1
		}
		passes += 1
	}
	return passes
}

func containsNegative(matrix [][]int) bool {
	for _, row := range matrix {
		for _, value := range row {
			if value < 0 {
				return true
			}
		}
	}
	return false
}

func getAllPositivePositions(matrix [][]int) []IntPair {
	positivePositions := make([]IntPair, 0)
	for row := range matrix {
		for col := range matrix[row] {
			value := matrix[row][col]
			if value > 0 {
				positivePositions = append(positivePositions, IntPair{row, col})
			}
		}
	}
	return positivePositions
}

func getAdjacentPositions(row, col int, matrix [][]int) []IntPair {
	adjacentPositions := make([]IntPair, 0)
	if row > 0 {
		adjacentPositions = append(adjacentPositions, IntPair{row - 1, col})
	}
	if row < len(matrix)-1 {
		adjacentPositions = append(adjacentPositions, IntPair{row + 1, col})
	}
	if col > 0 {
		adjacentPositions = append(adjacentPositions, IntPair{row, col - 1})
	}
	if col < len(matrix[0])-1 {
		adjacentPositions = append(adjacentPositions, IntPair{row, col + 1})
	}
	return adjacentPositions
}
