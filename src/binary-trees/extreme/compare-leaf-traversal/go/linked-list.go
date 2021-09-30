// Connect all of the leaf nodes in each individual tree so as to form two linked lists.
// Use leaf node's right  pointers to store the next leaf nodes in the leaf traversals.
// Reusing the input trees to store the leaf traversals, the only extra space comes from
// the recursion used in the traversal of the trees.
// Once both trees have their leaf nodes connected, iterate through the linked lists and
// check if they're the same keeping track of their heads.
package main

type BinaryTree struct {
	Value int
	Left  *BinaryTree
	Right *BinaryTree
}

type TreePair struct {
	First  *BinaryTree
	Second *BinaryTree
}

// O(n + m) t ime | O(max(h1,h2)) space
// where N is the number of nodes in the first Binary Tree, M in the second Binary Tree
// H1 and H2 are the height of the first and second Binary Trees respectively
func CompareLeafTraversal(tree1 *BinaryTree, tree2 *BinaryTree) bool {
	tree1LeafNodesList := connectLeafNodes(tree1, nil, nil).First
	tree2LeafNodesList := connectLeafNodes(tree2, nil, nil).First

	list1CurrentNode := tree1LeafNodesList
	list2CurrentNode := tree2LeafNodesList
	for list1CurrentNode != nil && list2CurrentNode != nil {
		if list1CurrentNode.Value != list2CurrentNode.Value {
			return false
		}
		list1CurrentNode = list1CurrentNode.Right
		list2CurrentNode = list2CurrentNode.Right
	}
	return list1CurrentNode == nil && list2CurrentNode == nil
}

func connectLeafNodes(current, head, previous *BinaryTree) TreePair {
	if current == nil {
		return TreePair{head, previous}
	}
	newHead := head
	newPrev := previous

	if isLeafNode(current) {
		if previous == nil {
			newHead = current
		} else {
			previous.Right = current
		}
		newPrev = current
	}

	leftPair := connectLeafNodes(current.Left, newHead, newPrev)
	leftHead, leftPrev := leftPair.First, leftPair.Second
	return connectLeafNodes(current.Right, leftHead, leftPrev)
}

func isLeafNode(node *BinaryTree) bool {
	return node.Left == nil && node.Right == nil
}
