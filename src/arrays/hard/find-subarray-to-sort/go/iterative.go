package main

import (
	"math"
)

// O(n) time | O(1) space
func SubarraySort(array []int) []int {
	minNotOrdered, maxNotOrdered := math.MaxInt32, math.MinInt32
	for i, num := range array {
		if isNotInOrder(i, num, array) {
			minNotOrdered = min(minNotOrdered, num)
			maxNotOrdered = max(maxNotOrdered, num)
		}
	}
	if minNotOrdered == math.MaxInt32 {
		return []int{-1, -1}
	}
	subarrayLeft := 0
	for minNotOrdered >= array[subarrayLeft] {
		subarrayLeft += 1
	}
	subarrayRight := len(array) - 1
	for maxNotOrdered <= array[subarrayRight] {
		subarrayRight -= 1
	}
	return []int{subarrayLeft, subarrayRight}
}

func isNotInOrder(i, num int, array []int) bool {
	if i == 0 {
		return num > array[i+1]
	}
	if i == len(array)-1 {
		return num < array[i-1]
	}
	return num > array[i+1] || num < array[i-1]
}

func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}

func max(a, b int) int {
	if a < b {
		return b
	}
	return a
}
