package main

// O(n.log(n)) time | O(n) space - where N is the length of the array
func MinHeightBST(array []int) *BST {
	return constructMinHeightBst(array, nil, 0, len(array)-1)
}

func constructMinHeightBst(array []int, bst *BST, start, end int) *BST {
	if end < start {
		return nil
	}
	mid := (start + end) / 2
	value := array[mid]
	if bst == nil {
		bst = &BST{Value: value}
	} else {
		bst.Insert(value)
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

func (tree *BST) Insert(value int) *BST {
	if value < tree.Value {
		if tree.Left == nil {
			tree.Left = &BST{Value: value}
		} else {
			tree.Left.Insert(value)
		}
	} else {
		if tree.Right == nil {
			tree.Right = &BST{Value: value}
		} else {
			tree.Right.Insert(value)
		}
	}
	return tree
}
