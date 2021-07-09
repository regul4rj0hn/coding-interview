package main

// O(n) time | O(1) space
// whare N is the length of the input array
func IsMonotonic(array []int) bool {
	isNonDecreasing, isNonIncreasing := true, true
	for i := 1; i < len(array); i++ {
		if array[i] < array[i-1] {
			isNonDecreasing = false
		}
		if array[i] > array[i-1] {
			isNonIncreasing = false
		}
	}
	return isNonDecreasing || isNonIncreasing
}
