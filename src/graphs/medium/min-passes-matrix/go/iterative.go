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

// In Go, removing elements from the start of a list is an O(n)-time operation
// To make this an O(1)-time operation, we could use a more legitimate queue structure.
// For our time complexity analysis, we'll assume this runs in O(1) time.
// Alternatively for this solution we could turn the queue into a stack and replace dequeue for stack pop
func convertNegatives(matrix [][]int) int {
	nextPassQueue := getAllPositivePositions(matrix)
	var passes = 0
	for len(nextPassQueue) > 0 {
		currentPassQueue := nextPassQueue
		nextPassQueue = make([]IntPair, 0)

		for len(currentPassQueue) > 0 {
			firstElement := currentPassQueue[0]
			currentPassQueue = currentPassQueue[1:]
			currentRow, currentCol := firstElement.First, firstElement.Second

			adjacentPositions := getAdjacentPositions(currentRow, currentCol, matrix)
			for _, position := range adjacentPositions {
				row, col := position.First, position.Second
				value := matrix[row][col]
				if value < 0 {
					matrix[row][col] *= -1
					nextPassQueue = append(nextPassQueue, IntPair{row, col})
				}
			}
		}
		passes += 1
	}
	return passes
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
