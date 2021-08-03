package main

import (
	"sort"
)

// O(n^2) time | O(n) space
func ThreeNumberSum(array []int, target int) [][]int {
	sort.Ints(array)
	triplets := [][]int{}
	for i := 0; i < len(array)-2; i++ {
		left, right := i+1, len(array)-1
		for left < right {
			sum := array[i] + array[left] + array[right]
			if sum == target {
				triplets = append(triplets, []int{array[i], array[left], array[right]})
				left += 1
				right -= 1
				continue
			}
			if sum < target {
				left += 1
				continue
			}
			right -= 1
		}
	}
	return triplets
}
