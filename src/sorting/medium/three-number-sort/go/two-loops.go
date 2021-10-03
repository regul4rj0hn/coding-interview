package main

// O(n) time | O(1) space - where N is the length of the array
func ThreeNumberSort(array []int, order []int) []int {
	firstValue, secondValue := order[0], order[1]
	firstIdx, secondIdx, thirdIdx := 0, 0, len(array)-1

	for secondIdx <= thirdIdx {
		value := array[secondIdx]
		if value == firstValue {
			array[firstIdx], array[secondIdx] = array[secondIdx], array[firstIdx]
			firstIdx += 1
			secondIdx += 1
		} else if value == secondValue {
			secondIdx += 1
		} else {
			array[secondIdx], array[thirdIdx] = array[thirdIdx], array[secondIdx]
			thirdIdx -= 1
		}
	}
	return array
}
