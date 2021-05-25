package main

// O(b.n.s) time | O(n) space | Where :
// B is the length of the big string
// N is the number of small strings
// S is the length of the longest small string
func MultiStringSearch(bigString string, smallStrings []string) []bool {
	output := make([]bool, len(smallStrings))
	for i, str := range smallStrings {
		output[i] = containsString(bigString, str)
	}
	return output
}

func containsString(str1, str2 string) bool {
	for i := range str1 {
		if i+len(str2) > len(str1) {
			break
		}
		if containsStringAfterIndex(str1, str2, i) {
			return true
		}
	}
	return false
}

func containsStringAfterIndex(str1, str2 string, start int) bool {
	leftOne := start
	rightOne := start + len(str2) - 1
	leftTwo := 0
	rightTwo := len(str2) - 1

	for leftOne <= rightOne {
		if str1[leftOne] != str2[leftTwo] || str1[rightOne] != str2[rightTwo] {
			return false
		}
		leftOne += 1
		rightOne -= 1
		leftTwo += 1
		rightTwo -= 1
	}

	return true
}
