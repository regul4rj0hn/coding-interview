package main

// O(log(n)) time | O(log(n)) space
func ShiftedBinarySearch(array []int, target int) int {
	return shiftBinarySearch(array, target, 0, len(array)-1)
}

func shiftBinarySearch(array []int, target, left, right int) int {
	if left > right {
		return -1
	}
	middle := (left + right) / 2
	match := array[middle]
	leftNum, rightNum := array[left], array[right]
	newLeft, newRight := middle+1, right
	if target == match {
		return middle
	}
	if leftNum <= match {
		if target < match && target >= leftNum {
			newLeft, newRight = left, middle-1
		}
	} else {
		if !(target > match && target < rightNum) {
			newLeft, newRight = left, middle-1
		}
	}
	return shiftBinarySearch(array, target, newLeft, newRight)
}
