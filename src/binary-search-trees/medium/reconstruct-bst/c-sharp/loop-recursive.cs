using System.Collections.Generic;
using System;

/*
The key to the solution is knowing that we can reconstruct the tree due to the fact that it's a Binary Search Tree. A pre-order traversal would not be enough information to re-build a common binary tree.
To approach the solution for this problem, consider that he right child of any BST node is simply the first node in the pre-order traversal list whose value is larger than or equal to the target node's value.
From this fact, we know that the nodes in the pre-order traversal that come before the right child of a node must be in the left subtree of that node.
Once that we determine the right child of any given node, we're able to generate the entire left and right subtrees of that node by recursively creating the left and right child nodes of the subsequent node. 
A node that has no left and right children is naturally a leaf node.

Time : O(n^2) - Where N is the length of the input list (and nodes in the tree). We are going to have N recursive calls and for each call traverse the N elements on the list until we find the right child node.
Space: O(h+n) - Where H is the height of the BST, to store the frames on the recursive calls stack and N nodes of our output tree.
*/
public class Program {
    public class BST {
        public int value;
        public BST left = null;
        public BST right = null;

        public BST (int value) {
            this.value = value;
        }
    }

    public BST ReconstructBst (List<int> preOrderTraversalValues) {
        if (preOrderTraversalValues.Count == 0) {
            return null;
        }

        var currentValue = preOrderTraversalValues[0];
        var rightSubtreeRootIdx = preOrderTraversalValues.Count;

        for (int i = 1; i < preOrderTraversalValues.Count; i++) {
            var val = preOrderTraversalValues[i];
            if (val >= currentValue) {
                rightSubtreeRootIdx = i;
                break;
            }
        }

        var leftSubtree = ReconstructBst (preOrderTraversalValues.GetRange (1, rightSubtreeRootIdx - 1));
        var rightSubtree = ReconstructBst (preOrderTraversalValues.GetRange (rightSubtreeRootIdx, preOrderTraversalValues.Count - rightSubtreeRootIdx));

        var bst = new BST (currentValue);
        bst.left = leftSubtree;
        bst.right = rightSubtree;

        return bst;
    }
}