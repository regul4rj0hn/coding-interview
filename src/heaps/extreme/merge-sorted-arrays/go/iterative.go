package main

type Item struct {
	Index int
	Value int
}

// O(nk) time | O(n+k) space
// where N is the total number of array elements and K is the number of arrays
func MergeSortedArrays(arrays [][]int) []int {
	sortedList := []int{}
	elementIdxList := make([]int, len(arrays))

	for {
		smallestItems := []Item{}
		for i := 0; i < len(arrays); i++ {
			relevantArray := arrays[i]
			element := elementIdxList[i]
			if element == len(relevantArray) {
				continue
			}
			smallestItems = append(smallestItems, Item{Index: i, Value: relevantArray[element]})
		}
		if len(smallestItems) == 0 {
			break
		}
		nextItem := getMinValue(smallestItems)
		sortedList = append(sortedList, nextItem.Value)
		elementIdxList[nextItem.Index] += 1
	}

	return sortedList
}

func getMinValue(items []Item) Item {
	minValueItem := items[0]
	for i := 1; i < len(items); i++ {
		if items[i].Value < minValueItem.Value {
			minValueItem = items[i]
		}
	}
	return minValueItem
}
