package main

// O(n^2) time | O(n) space
// where N is the length of the stack
func SortStack(stack []int) []int {
	if len(stack) == 0 {
		return stack
	}
	top := stack[len(stack)-1]
	stack = stack[:len(stack)-1]
	SortStack(stack)
	insertInSortedOrder(&stack, top)
	return stack
}

func insertInSortedOrder(stack *[]int, value int) {
	if len(*stack) == 0 || (*stack)[len(*stack)-1] <= value {
		*stack = append(*stack, value)
		return
	}

	top := (*stack)[len(*stack)-1]
	*stack = (*stack)[:len(*stack)-1]
	insertInSortedOrder(stack, value)
	*stack = append(*stack, top)
}
