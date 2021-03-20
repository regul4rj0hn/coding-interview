using System;
using System.Collections.Generic;

public class Program {

    // First traverse the left subtree and add the bottom left-most node, then its parent node, then the right children node.
    // On a valid BST, the resulting array is sorted.
    // O(n) time | O(n) space
    public static List<int> InOrderTraverse (BST tree, List<int> array) {
        if (tree.left != null) {
            InOrderTraverse (tree.left, array);
        }
        array.Add (tree.value);
        if (tree.right != null) {
            InOrderTraverse (tree.right, array);
        }
        return array;
    }

    // First add the current parent node, then call recursively on the left, and then the right subtrees.
    // The resulting array is topologically sorted (parent nodes are always processed before any children nodes)
    // O(n) time | O(n) space
    public static List<int> PreOrderTraverse (BST tree, List<int> array) {
        array.Add (tree.value);
        if (tree.left != null) {
            PreOrderTraverse (tree.left, array);
        }
        if (tree.right != null) {
            PreOrderTraverse (tree.right, array);
        }
        return array;
    }

    // Traverse the left subtree, traverse the right subtree, and then add the current node.
    // The resulting array is call a "sequentialisation" of the tree
    // O(n) time | O(n) space
    public static List<int> PostOrderTraverse (BST tree, List<int> array) {
        if (tree.left != null) {
            PostOrderTraverse (tree.left, array);
        }
        if (tree.right != null) {
            PostOrderTraverse (tree.right, array);
        }
        array.Add (tree.value);
        return array;
    }

    public class BST {
        public int value;
        public BST left;
        public BST right;

        public BST(int value) {
            this.value = value;
        }
    }
}
