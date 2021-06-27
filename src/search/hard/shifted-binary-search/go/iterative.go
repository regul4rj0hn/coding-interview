package main

// O(log(n)) time | O(1) space
func ShiftedBinarySearch(array []int, target int) int {
	return shiftBinarySearch(array, target, 0, len(array)-1)
}

func shiftBinarySearch(array []int, target, left, right int) int {
	for left <= right {
		middle := (left + right) / 2
		match := array[middle]
		leftNum, rightNum := array[left], array[right]
		if target == match {
			return middle
		}
		if leftNum <= match {
			if target < match && target >= leftNum {
				right = middle - 1
			} else {
				left = middle + 1
			}
		} else {
			if target > match && target <= rightNum {
				left = middle + 1
			} else {
				right = middle - 1
			}
		}
	}
	return -1
}
