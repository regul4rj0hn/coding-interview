package main

func Fill(array []int, val int) {
	for i := range array {
		array[i] = val
	}
}

func Sum(array []int) int {
	sum := 0
	for i := range array {
		sum += array[i]
	}
	return sum
}

func Max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
