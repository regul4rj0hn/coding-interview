package main

import (
	"math"
)

// O(n^2) time | O(n) space
func MaxSumIncreasingSubsequence(array []int) (int, []int) {
	sequences := make([]int, len(array))
	sums := make([]int, len(array))
	for i := range sequences {
		sequences[i] = math.MinInt32
		sums[i] = array[i]
	}
	maxSumIndex := 0
	for i, num := range array {
		for j := 0; j < i; j++ {
			otherNum := array[j]
			if otherNum < num && sums[j]+num >= sums[i] {
				sums[i] = sums[j] + num
				sequences[i] = j
			}
		}
		if sums[i] > sums[maxSumIndex] {
			maxSumIndex = i
		}
	}
	maxSum := sums[maxSumIndex]
	sequence := buildSequence(array, sequences, maxSumIndex)
	return maxSum, sequence
}

func buildSequence(array, sequences []int, index int) []int {
	sequence := []int{}
	for index != math.MinInt32 {
		sequence = append(sequence, array[index])
		index = sequences[index]
	}
	reverse(sequence)
	return sequence
}

func reverse(numbers []int) {
	for i, j := 0, len(numbers)-1; i < j; i, j = i+1, j-1 {
		numbers[i], numbers[j] = numbers[j], numbers[i]
	}
}
