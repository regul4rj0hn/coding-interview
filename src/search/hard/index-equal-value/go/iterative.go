package main

// O(n) time | O(1) space
// where N is the length of the input array
func IndexEqualsValue(array []int) int {
	for index, value := range array {
		if index == value {
			return index
		}
	}
	return -1
}
