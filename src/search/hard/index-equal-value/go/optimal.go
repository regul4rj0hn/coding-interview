package main

// O(log(n)) time | O(1) space
// where N is the length of the input array
func IndexEqualsValue(array []int) int {
	left := 0
	right := len(array) - 1

	for left <= right {
		mid := left + (right-left)/2
		value := array[mid]
		if value < mid {
			left = mid + 1
			continue
		}
		if value == mid && mid == 0 {
			return mid
		}
		if value == mid && array[mid-1] < mid-1 {
			return mid
		}
		right = mid - 1
	}
	return -1
}
