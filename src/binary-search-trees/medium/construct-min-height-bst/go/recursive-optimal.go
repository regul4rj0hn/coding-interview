package main

// O(n) time | O(n) space - where N is the length of the array
func MinHeightBST(array []int) *BST {
	return constructMinHeightBst(array, 0, len(array)-1)
}

func constructMinHeightBst(array []int, start, end int) *BST {
	if end < start {
		return nil
	}
	mid := (start + end) / 2
	bst := &BST{Value: array[mid]}
	bst.Left = constructMinHeightBst(array, start, mid-1)
	bst.Right = constructMinHeightBst(array, mid+1, end)
	return bst
}

type BST struct {
	Value int
	Left  *BST
	Right *BST
}
