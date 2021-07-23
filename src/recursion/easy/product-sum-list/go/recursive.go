package main

type SpecialArray []interface{}

// O(n) time | O(d) space
// where N is the total number of elements in the array including sub-elements
// where D is the greatest depth of "special" arrays in the array
func ProductSum(array []interface{}) int {
	return productSum(array, 1)
}

func productSum(array SpecialArray, multiplier int) int {
	sum := 0
	for _, element := range array {
		if cast, ok := element.(SpecialArray); ok {
			sum += productSum(cast, multiplier+1)
		} else if cast, ok := element.(int); ok {
			sum += cast
		}
	}
	return sum * multiplier
}
