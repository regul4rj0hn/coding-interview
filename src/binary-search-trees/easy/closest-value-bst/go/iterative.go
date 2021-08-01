package main

type BST struct {
	Value int
	Left  *BST
	Right *BST
}

// Average: O(log(n)) time | O(1) space
// Worst  : O(n)      time | O(1) space
func (tree *BST) FindClosestValue(target int) int {
	return tree.findClosestValue(target, tree.Value)
}

func (tree *BST) findClosestValue(target, closest int) int {
	current := tree
	for current != nil {
		if absDiff(target, closest) > absDiff(target, current.Value) {
			closest = current.Value
		}
		if target < current.Value {
			current = current.Left
			continue
		}
		if target > current.Value {
			current = current.Right
		} else {
			break
		}
	}
	return closest
}

func absDiff(a, b int) int {
	if a > b {
		return a - b
	}
	return b - a
}
