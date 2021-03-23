using System;
using System.Collections.Generic;

public class Program {
    public class BST
    {
        public int value;
        public BST left = null;
        public BST right = null;

        public BST (int value)
        {
            this.value = value;
        }
    }

    // The brute-force approach to this problem is to simply perform an in-order traversal of the BST and to store all of its node' values in the order in which they're visited. 
    // Since an in-order traversal of a BST visits the nodes in ascending order, the Kth value from the end of the traversal order will be the Kth largest
    // O(n) time | O(n) space where N is the number of nodes in the tree
    public int FindKthLargestValueInBst (BST tree, int k) {
        var inOrderBst = new List<int>();
        InOrderTraverse (tree, inOrderBst);
        return inOrderBst[inOrderBst.Count - k];
    }

    private void InOrderTraverse (BST node, List<int> tree) {
        if (node == null) {
            return;
        }

        InOrderTraverse (node.left, tree);
        tree.Add (node.value);
        InOrderTraverse (node.right, tree);
    }
}
