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

	lastIdx := len(array) - 1
	bst := NewSpecialBST(array[lastIdx], lastIdx, 0)
	for i := lastIdx - 1; i >= 0; i-- {
		bst.Insert(array[i], i)
	}

	countsList := make([]int, 0, len(array))
	for _, i := range array {
		countsList = append(countsList, i)
	}
	getRightSmallerCounts(bst, countsList)

	return countsList
}

func getRightSmallerCounts(bst *SpecialBST, list []int) {
	if bst == nil {
		return
	}
	list[bst.Index] = bst.SmallerCountAtInsert
	getRightSmallerCounts(bst.Left, list)
	getRightSmallerCounts(bst.Right, list)
}

type SpecialBST struct {
	Value                int
	Index                int
	SmallerCountAtInsert int
	LeftSubtreeSize      int
	Left                 *SpecialBST
	Right                *SpecialBST
}

func NewSpecialBST(value, idx, smallerCount int) *SpecialBST {
	return &SpecialBST{
		Value:                value,
		Index:                idx,
		SmallerCountAtInsert: smallerCount,
		LeftSubtreeSize:      0,
		Left:                 nil,
		Right:                nil,
	}
}

func (bst *SpecialBST) Insert(value, idx int) {
	bst.insert(value, idx, 0)
}

func (bst *SpecialBST) insert(value, idx, smallerCount int) {
	if value < bst.Value {
		bst.LeftSubtreeSize += 1
		if bst.Left == nil {
			bst.Left = NewSpecialBST(value, idx, smallerCount)
		} else {
			bst.Left.insert(value, idx, smallerCount)
		}
		return
	}
	smallerCount += bst.LeftSubtreeSize
	if value > bst.Value {
		smallerCount += 1
	}

	if bst.Right == nil {
		bst.Right = NewSpecialBST(value, idx, smallerCount)
	} else {
		bst.Right.insert(value, idx, smallerCount)
	}
}
