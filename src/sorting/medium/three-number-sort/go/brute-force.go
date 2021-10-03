package main

// O(n) time | O(1) space - where N is the length of the array
func ThreeNumberSort(array []int, order []int) []int {
	valueCounts := []int{0, 0, 0}
	for _, element := range array {
		orderIdx := indexOf(order, element)
		valueCounts[orderIdx] += 1
	}

	for i := 0; i < 3; i++ {
		value := order[i]
		count := valueCounts[i]

		numElementsBefore := sumSublist(valueCounts, i)
		for n := 0; n < count; n++ {
			currentIdx := numElementsBefore + n
			array[currentIdx] = value
		}
	}
	return array
}

func indexOf(order []int, element int) int {
	for i, item := range order {
		if item == element {
			return i
		}
	}
	return -1
}

func sumSublist(list []int, end int) int {
	sum := 0
	for i, value := range list {
		if i >= end {
			return sum
		}
		sum += value
	}
	return sum
}
