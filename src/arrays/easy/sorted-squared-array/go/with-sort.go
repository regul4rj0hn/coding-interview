package main

import (
	"sort"
)

// O(n.log(n)) time | O(n) space - where N is the length of the input array
func SortedSquaredArray(array []int) []int {
	squares := make([]int, len(array))
	for i, num := range array {
		squares[i] = num * num
	}
	sort.Ints(squares)
	return squares
}
