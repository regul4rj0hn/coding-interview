package main

// O(n) time | O(n) space - where N is the length of the array
func MinHeightBST(array []int) *BST {
	return constructMinHeightBst(array, nil, 0, len(array)-1)
}

func constructMinHeightBst(array []int, bst *BST, start, end int) *BST {
	if end < start {
		return nil
	}
	mid := (start + end) / 2
	node := &BST{Value: array[mid]}
	if bst == nil {
		bst = node
	} else {
		if array[mid] < bst.Value {
			bst.Left = node
			bst = bst.Left
		} else {
			bst.Right = node
			bst = bst.Right
		}
	}
	constructMinHeightBst(array, bst, start, mid-1)
	constructMinHeightBst(array, bst, mid+1, end)
	return bst
}

type BST struct {
	Value int
	Left  *BST
	Right *BST
}
