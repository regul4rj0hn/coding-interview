package main

func NextGreaterElement(array []int) []int {
	output := make([]int, 0)
	for range array {
		output = append(output, -1)
	}
	stack := make([]int, 0)

	for i := 0; i < 2*len(array); i++ {
		circularIndex := i % len(array)
		for len(stack) > 0 && array[stack[len(stack)-1]] < array[circularIndex] {
			var top int
			top, stack = stack[len(stack)-1], stack[:len(stack)-1]
			output[top] = array[circularIndex]
		}
		stack = append(stack, circularIndex)
	}
	return output
}
