package main

// O(n) time | O(n) space - where N is the length of the input array
func SortedSquaredArray(array []int) []int {
	squares := make([]int, len(array))
	left := 0
	right := len(array) - 1
	for i := len(array) - 1; i >= 0; i-- {
		leftVal := array[left]
		rightVal := array[right]
		if abs(leftVal) > abs(rightVal) {
			squares[i] = leftVal * leftVal
			left += 1
		} else {
			squares[i] = rightVal * rightVal
			right -= 1
		}
	}
	return squares
}

func abs(a int) int {
	if a < 0 {
		return -a
	}
	return a
}
