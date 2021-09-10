package main

type BinaryTree struct {
	Value int
	Left  *BinaryTree
	Right *BinaryTree
}

// O(n) time | O(n) space - where N is the number of nodes in the tree
func FindNodesDistanceK(tree *BinaryTree, target int, k int) []int {
	nodesDistanceK := []int{}
	findDistanceFromNodeToTarget(tree, target, k, &nodesDistanceK)
	return nodesDistanceK
}

func findDistanceFromNodeToTarget(node *BinaryTree, target, k int, nodesDistanceK *[]int) int {
	if node == nil {
		return -1
	}
	if node.Value == target {
		addSubtreeNodesAtDistanceK(node, 0, k, nodesDistanceK)
		return 1
	}

	leftDist := findDistanceFromNodeToTarget(node.Left, target, k, nodesDistanceK)
	rightDist := findDistanceFromNodeToTarget(node.Right, target, k, nodesDistanceK)
	if leftDist == k || rightDist == k {
		*nodesDistanceK = append(*nodesDistanceK, node.Value)
	}
	if leftDist != -1 {
		addSubtreeNodesAtDistanceK(node.Right, leftDist+1, k, nodesDistanceK)
		return leftDist + 1
	}
	if rightDist != -1 {
		addSubtreeNodesAtDistanceK(node.Left, rightDist+1, k, nodesDistanceK)
		return rightDist + 1
	}
	return -1
}

func addSubtreeNodesAtDistanceK(node *BinaryTree, dist, k int, nodesDistanceK *[]int) {
	if node == nil {
		return
	}
	if dist == k {
		*nodesDistanceK = append(*nodesDistanceK, node.Value)
	} else {
		addSubtreeNodesAtDistanceK(node.Left, dist+1, k, nodesDistanceK)
		addSubtreeNodesAtDistanceK(node.Right, dist+1, k, nodesDistanceK)
	}
}
