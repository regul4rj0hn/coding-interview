package main

// O(n^2) time | O(n) space
func MinNumberOfJumps(array []int) int {
	jumps := make([]int, len(array))
	for i := range jumps {
		jumps[i] = -1
	}
	jumps[0] = 0
	for i := 1; i < len(array); i++ {
		for j := 0; j < i; j++ {
			if array[j] >= i-j && jumps[i] == -1 || jumps[j]+1 < jumps[i] {
				jumps[i] = jumps[j] + 1
			}
		}
	}
	return jumps[len(array)-1]
}
