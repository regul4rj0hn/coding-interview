package main

// O(n^2) time | O(1) space
// where N is the length of the input array
func FirstDuplicateValue(array []int) int {
	minSecondIndex := len(array)
	for i := 0; i < len(array); i++ {
		value := array[i]
		for j := i + 1; j < len(array); j++ {
			compareValue := array[j]
			if value == compareValue {
				minSecondIndex = min(minSecondIndex, j)
			}
		}
	}
	if minSecondIndex == len(array) {
		return -1
	}

	return array[minSecondIndex]
}

func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}
