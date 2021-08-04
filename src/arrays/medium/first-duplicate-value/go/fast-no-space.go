package main

// O(n) time | O(1) space
// where N is the length of the input array
func FirstDuplicateValue(array []int) int {
	for _, value := range array {
		absValue := abs(value)
		if array[absValue-1] < 0 {
			return absValue
		}
		array[absValue-1] *= -1
	}
	return -1
}

func abs(a int) int {
	if a < 0 {
		return -a
	}
	return a
}
