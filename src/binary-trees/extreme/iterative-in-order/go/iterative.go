package main

type BinaryTree struct {
	Value  int
	Left   *BinaryTree
	Right  *BinaryTree
	Parent *BinaryTree
}

// O(n) time | O(1) space
func (tree *BinaryTree) IterativeInOrderTraversal(callback func(int)) {
	var previous, next *BinaryTree
	current := tree
	for current != nil {
		if previous == nil || previous == current.Parent {
			if current.Left != nil {
				next = current.Left
			} else {
				callback(current.Value)
				if current.Right != nil {
					next = current.Right
				} else {
					next = current.Parent
				}
			}
		} else if previous == current.Left {
			callback(current.Value)
			if current.Right != nil {
				next = current.Right
			} else {
				next = current.Parent
			}
		} else {
			next = current.Parent
		}
		previous, current = current, next
	}
}
