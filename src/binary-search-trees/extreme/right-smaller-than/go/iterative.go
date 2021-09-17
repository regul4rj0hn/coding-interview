package main

// O(n^2) time | O(n) space
// Where N is the length of the input array
func RightSmallerThan(array []int) []int {
	countsList := []int{}
	for i := 0; i < len(array); i++ {
		count := 0
		for j := i + 1; j < len(array); j++ {
			if array[j] < array[i] {
				count += 1
			}
		}
		countsList = append(countsList, count)
	}
	return countsList
}
