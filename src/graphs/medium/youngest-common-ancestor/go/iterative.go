package main

type AncestralTree struct {
	Name     string
	Ancestor *AncestralTree
}

// O(d) time | O(1) space
// where D is the depth/height fo the ancestral tree
func GetYoungestCommonAncestor(top, descendantOne, descendantTwo *AncestralTree) *AncestralTree {
	depthOne := getDescendantDepth(descendantOne, top)
	depthTwo := getDescendantDepth(descendantTwo, top)
	if depthOne > depthTwo {
		return backtrackAncestralTree(descendantOne, descendantTwo, depthOne-depthTwo)
	}
	return backtrackAncestralTree(descendantTwo, descendantOne, depthTwo-depthOne)
}

func getDescendantDepth(desc, top *AncestralTree) int {
	depth := 0
	for desc != top {
		depth++
		desc = desc.Ancestor
	}
	return depth
}

func backtrackAncestralTree(lowerDesc, higherDesc *AncestralTree, diff int) *AncestralTree {
	for diff > 0 {
		lowerDesc = lowerDesc.Ancestor
		diff--
	}
	for lowerDesc != higherDesc {
		lowerDesc = lowerDesc.Ancestor
		higherDesc = higherDesc.Ancestor
	}
	return lowerDesc
}
