package main

// Best (sorted): O(n) time | O(1) space
// Average/Worst: O(n^2) time | O(1) space
func InsertionSort(array []int) []int {
	for i := range array {
		for j := i; j > 0 && array[j] < array[j-1]; j-- {
			array[j], array[j-1] = array[j-1], array[j]
		}
	}
	return array
}
