package main

type BinaryTree struct {
	Value int
	Left  *BinaryTree
	Right *BinaryTree
}

// O(n) time | O(n) space - where N is the number of nodes in the tree
func FindNodesDistanceK(tree *BinaryTree, target int, k int) []int {
	nodesToParents := map[int]*BinaryTree{}
	populateNodesToParents(tree, nodesToParents, nil)
	targetNode := getNodeFromValue(target, tree, nodesToParents)
	return breadthFirstSearchForDistanceKNodes(targetNode, nodesToParents, k)
}

func populateNodesToParents(node *BinaryTree, nodesToParents map[int]*BinaryTree, parent *BinaryTree) {
	if node != nil {
		nodesToParents[node.Value] = parent
		populateNodesToParents(node.Left, nodesToParents, node)
		populateNodesToParents(node.Right, nodesToParents, node)
	}
}

func getNodeFromValue(value int, tree *BinaryTree, nodesToParents map[int]*BinaryTree) *BinaryTree {
	if tree.Value == value {
		return tree
	}
	nodeParent := nodesToParents[value]
	if nodeParent.Left != nil && nodeParent.Left.Value == value {
		return nodeParent.Left
	}
	return nodeParent.Right
}

func breadthFirstSearchForDistanceKNodes(target *BinaryTree, nodesToParents map[int]*BinaryTree, k int) []int {
	type item struct {
		node *BinaryTree
		dist int
	}
	queue := []item{{node: target, dist: 0}}
	seen := map[int]bool{target.Value: true}
	var current item
	for len(queue) > 0 {
		current, queue = queue[0], queue[1:]
		currentNode, targetDistance := current.node, current.dist

		if targetDistance == k {
			nodesDistanceK := make([]int, 0)
			for _, i := range queue {
				nodesDistanceK = append(nodesDistanceK, i.node.Value)
			}
			nodesDistanceK = append(nodesDistanceK, currentNode.Value)
			return nodesDistanceK
		}

		connectedNodes := []*BinaryTree{currentNode.Left, currentNode.Right, nodesToParents[currentNode.Value]}
		for _, node := range connectedNodes {
			if node == nil {
				continue
			}
			if seen[node.Value] {
				continue
			}
			seen[node.Value] = true
			queue = append(queue, item{node: node, dist: targetDistance + 1})
		}
	}
	return []int{}
}
