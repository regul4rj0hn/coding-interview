package main

// O(n) time | O(1) space
// where N is the length of the input array
func HasSingleCycle(array []int) bool {
	elementsVisited := 0
	index := 0
	for elementsVisited < len(array) {
		if elementsVisited > 0 && index == 0 {
			return false
		}
		elementsVisited++
		index = getNextIndex(index, array)
	}
	return index == 0
}

func getNextIndex(index int, array []int) int {
	jump := array[index]
	nextIndex := (index + jump) % len(array)
	if nextIndex >= 0 {
		return nextIndex
	}
	return nextIndex + len(array)
}
