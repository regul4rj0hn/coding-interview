package main

type BST struct {
	Value int
	Left  *BST
	Right *BST
}

// O(d) time | O(1) space - where D is the distance between input nodeOne and nodeThree
func ValidateThreeNodes(nodeOne *BST, nodeTwo *BST, nodeThree *BST) bool {
	searchOne := nodeOne
	searchTwo := nodeThree

	for {
		foundThreeFromOne := searchOne == nodeThree
		foundOneFromThree := searchTwo == nodeOne
		foundNodeTwo := searchOne == nodeTwo || searchTwo == nodeTwo
		finishSearch := searchOne == nil && searchTwo == nil
		if foundThreeFromOne || foundOneFromThree || foundNodeTwo || finishSearch {
			break
		}

		if searchOne != nil {
			if searchOne.Value > nodeTwo.Value {
				searchOne = searchOne.Left
			} else {
				searchOne = searchOne.Right
			}
		}

		if searchTwo != nil {
			if searchTwo.Value > nodeTwo.Value {
				searchTwo = searchTwo.Left
			} else {
				searchTwo = searchTwo.Right
			}
		}
	}

	foundNodeFromOther := searchOne == nodeThree || searchTwo == nodeOne
	foundNodeTwo := searchOne == nodeTwo || searchTwo == nodeTwo
	if !foundNodeTwo || foundNodeFromOther {
		return false
	}
	if searchOne == nodeTwo {
		return searchForTarget(nodeTwo, nodeThree)
	}
	return searchForTarget(nodeTwo, nodeOne)
}

func searchForTarget(node *BST, target *BST) bool {
	current := node
	for current != nil && current != target {
		if target.Value < current.Value {
			current = current.Left
		} else {
			current = current.Right
		}
	}
	return current == target
}
