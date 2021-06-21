package main

type BinaryTree struct {
	Value  int
	Left   *BinaryTree
	Right  *BinaryTree
	Parent *BinaryTree
}

// O(n) time | O(n) space
// where N is the number of nodes in the tree
func FindSuccessor(tree *BinaryTree, node *BinaryTree) *BinaryTree {
	inOrderTraverse := []*BinaryTree{}
	getInOrderTraversalOrder(tree, &inOrderTraverse)

	for i, currentNode := range inOrderTraverse {
		if currentNode != node {
			continue
		}
		if i == len(inOrderTraverse)-1 {
			return nil
		}
		return inOrderTraverse[i+1]
	}

	return nil
}

func getInOrderTraversalOrder(node *BinaryTree, order *[]*BinaryTree) {
	if node == nil {
		return
	}

	getInOrderTraversalOrder(node.Left, order)
	*order = append(*order, node)
	getInOrderTraversalOrder(node.Right, order)
}
