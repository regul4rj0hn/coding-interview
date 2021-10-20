// This is the class of the input root
class BinaryTree {
constructor(value) {
    this.value = value;
    this.left = null;
    this.right = null;
}
}

// O(n) time | O(n) space - where N is the number of nodes in the Binary Tree
function branchSums(root) {
    const sums = [];
        calculateBranchSums(root, 0, sums)
        return sums
}

function calculateBranchSums(node, sum, total) {
    if (!node) return
    const newSum = sum + node.value
    if (!node.left && !node.right) {
        total.push(newSum)
        return
    }
    calculateBranchSums(node.left, newSum, total)
    calculateBranchSums(node.right, newSum, total)
}

exports.BinaryTree = BinaryTree;
exports.branchSums = branchSums;
