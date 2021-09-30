// Do pre-order traversals of both trees and then compare the resulting arrays
package main

type BinaryTree struct {
	Value int
	Left  *BinaryTree
	Right *BinaryTree
}

// O(n + m) t ime | O(h1 + h2) space
// where N is the number of nodes in the first Binary Tree, M in the second Binary Tree
// H1 and H2 are the height of the first and second Binary Trees respectively
func CompareLeafTraversal(tree1 *BinaryTree, tree2 *BinaryTree) bool {
	tree1TraversalStack := []*BinaryTree{tree1}
	tree2TraversalStack := []*BinaryTree{tree2}

	for len(tree1TraversalStack) > 0 && len(tree2TraversalStack) > 0 {
		tree1Leaf := getNextLeafNode(&tree1TraversalStack)
		tree2Leaf := getNextLeafNode(&tree2TraversalStack)

		if tree1Leaf.Value != tree2Leaf.Value {
			return false
		}
	}
	return len(tree1TraversalStack) == 0 && len(tree2TraversalStack) == 0
}

// Add the left node to the stack after the right node so that it gets popped off first
func getNextLeafNode(stack *[]*BinaryTree) *BinaryTree {
	var currentNode *BinaryTree
	currentNode, *stack = (*stack)[len(*stack)-1], (*stack)[:len(*stack)-1]

	for !isLeafNode(currentNode) {
		if currentNode.Right != nil {
			*stack = append(*stack, currentNode.Right)
		}
		if currentNode.Left != nil {
			*stack = append(*stack, currentNode.Left)
		}
		currentNode, *stack = (*stack)[len(*stack)-1], (*stack)[:len(*stack)-1]
	}
	return currentNode
}

func isLeafNode(node *BinaryTree) bool {
	return node.Left == nil && node.Right == nil
}
