package main

// Where N is the length of the input array
// Average Case: when the BST is balanced
// O(n.log(n)) time | O(n) space
// Worst Case: when the BST is like a Linked List
// O(n^2)      time | O(n) space
func RightSmallerThan(array []int) []int {
	if len(array) == 0 {
		return []int{}
	}

	countsList := make([]int, 0, len(array))
	for _, i := range array {
		countsList = append(countsList, i)
	}

	lastIdx := len(array) - 1
	bst := NewSpecialBST(array[lastIdx])
	countsList[lastIdx] = 0
	for i := lastIdx - 1; i >= 0; i-- {
		bst.Insert(array[i], i, countsList)
	}

	return countsList
}

type SpecialBST struct {
	Value           int
	LeftSubtreeSize int
	Left            *SpecialBST
	Right           *SpecialBST
}

func NewSpecialBST(value int) *SpecialBST {
	return &SpecialBST{
		Value:           value,
		LeftSubtreeSize: 0,
		Left:            nil,
		Right:           nil,
	}
}

func (bst *SpecialBST) Insert(value, idx int, smallerCountList []int) {
	bst.insert(value, idx, smallerCountList, 0)
}

func (bst *SpecialBST) insert(value, idx int, smallerCountList []int, smallerCountAtInsert int) {
	if value < bst.Value {
		bst.LeftSubtreeSize += 1
		if bst.Left == nil {
			bst.Left = NewSpecialBST(value)
			smallerCountList[idx] = smallerCountAtInsert
		} else {
			bst.Left.insert(value, idx, smallerCountList, smallerCountAtInsert)
		}
		return
	}

	smallerCountAtInsert += bst.LeftSubtreeSize
	if value > bst.Value {
		smallerCountAtInsert += 1
	}

	if bst.Right == nil {
		bst.Right = NewSpecialBST(value)
		smallerCountList[idx] = smallerCountAtInsert
	} else {
		bst.Right.insert(value, idx, smallerCountList, smallerCountAtInsert)
	}
}
