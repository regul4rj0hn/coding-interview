package main

// O(d.(n + b)) time | O(n + b) space
// where N is the length of the input array, D is the max number of digits, and B is the base of the num system
func RadixSort(array []int) []int {
	if len(array) == 0 {
		return array
	}
	maxNum := max(array)
	digit := 0
	for maxNum/pow(10, digit) > 0 {
		countingSort(array, digit)
		digit += 1
	}
	return array
}

func countingSort(array []int, digit int) {
	sortedArray := make([]int, len(array))
	countArray := []int{0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
	digitColum := pow(10, digit)
	for _, num := range array {
		countIndex := (num / digitColum) % 10
		countArray[countIndex] += 1
	}
	for i := 1; i < 10; i++ {
		countArray[i] += countArray[i-1]
	}
	for i := len(array) - 1; i >= 0; i-- {
		countIndex := (array[i] / digitColum) % 10
		countArray[countIndex] -= 1
		sortedIndex := countArray[countIndex]
		sortedArray[sortedIndex] = array[i]
	}
	for i := range array {
		array[i] = sortedArray[i]
	}
}

func max(array []int) int {
	output := array[0]
	for _, element := range array {
		if output < element {
			output = element
		}
	}
	return output
}

func pow(base, power int) int {
	var output = 1
	for i := 0; i < power; i++ {
		output *= base
	}
	return output
}
