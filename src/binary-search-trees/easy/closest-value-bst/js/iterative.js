// Averg: O(log(n)) time | O(1) space
// Worst: O(n)			time | O(1) space
function findClosestValueInBst(tree, target) {
    let node = tree
    let closest = tree.value
    while (node !== null) {
        if (Math.abs(target - closest) > Math.abs(target - node.value)) {
            closest = node.value
        }
        if (target < node.value) {
            node = node.left
        } else if (target > node.value) {
            node = node.right
        } else {
            break
        }
    }
    return closest
}

// This is the class of the input tree
class BST {
    constructor(value) {
        this.value = value;
        this.left = null;
        this.right = null;
    }
}

exports.findClosestValueInBst = findClosestValueInBst;
