package main

type BinaryTree struct {
	Value int
	Left  *BinaryTree
	Right *BinaryTree
}

func BranchSums(root *BinaryTree) []int {
	sums := []int{}
	calculateBranchSums(root, 0, &sums)
	return sums
}

func calculateBranchSums(node *BinaryTree, sum int, sums *[]int) {
	if node == nil {
		return
	}
	sum += node.Value
	if node.Left == nil && node.Right == nil {
		*sums = append(*sums, sum)
		return
	}
	calculateBranchSums(node.Left, sum, sums)
	calculateBranchSums(node.Right, sum, sums)
}
