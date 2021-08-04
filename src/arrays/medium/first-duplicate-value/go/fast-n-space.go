package main

// O(n) time | O(n) space
// where N is the length of the input array
func FirstDuplicateValue(array []int) int {
	seen := map[int]bool{}
	for _, value := range array {
		if seen[value] {
			return value
		}
		seen[value] = true
	}
	return -1
}
