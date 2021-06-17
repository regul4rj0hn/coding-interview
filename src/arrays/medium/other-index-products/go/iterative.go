package main

// O(n) time | O(n) space
// where N is the number of elements in the input array
func ArrayOfProducts(array []int) []int {
	products := make([]int, len(array))
	for i := range array {
		products[i] = 1
	}

	leftProduct := 1
	for i := range array {
		products[i] = leftProduct
		leftProduct *= array[i]
	}

	rightProduct := 1
	for i := len(array) - 1; i >= 0; i-- {
		products[i] *= rightProduct
		rightProduct *= array[i]
	}

	return products
}
