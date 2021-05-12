package main

// O(log(n)) time | O(1) space
func BinarySearch(array []int, target int) int {
	left := 0
	right := len(array) - 1
	for left <= right {
		middle := (left + right) / 2
		match := array[middle]
		if target == match {
			return middle
		}
		if target < match {
			right = middle - 1
		} else {
			left = middle + 1
		}
	}
	return -1
}
