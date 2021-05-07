using System;

/*
To solve this problem it is important to identify that there are two patterns: 
 - if a node is the left child of another node, its right sibling is its parent's right child; 
 - if a node is the right child of another node, its right sibling is its parent's right sibling's left child.

It's not trivial to quickly access a node's parent's right child, and a node's parent's right sibling; because the second one implies that the parent node's original right pointer has been overwritten.

To overcome this, we recursively traverse the binary tree and sequence the transformation operations as followst any given node, recursively transform its left subtree into a right sibling tree, then edit the given node's right pointer to point to its right sibling, and then finally recursively transform its right subtree into a right sibling tree. 

The above sequencing of operations will allow left child nodes to always access their parent's right child (before their parent's right pointer gets overwritten to point to the parent's right sibling) and will allow right child nodes to always access their parent's right sibling (after their parent's right pointer has gotten overwritten to point to the parent's right sibling). The outcome code of this algorithm is pretty straight foward, so a trace really helps with understanding the problem.

Time : O(n) - Where N is the number of nodes in the input binary tree
Space: O(d) - Where D is the depth (height) of the binary tree
*/
public class Program {
    public static BinaryTree RightSiblingTree(BinaryTree root) {
        Mutate (root, null, false);
        return root;
    }

    private static void Mutate (BinaryTree node, BinaryTree parent, bool isLeftChild) {
        if (node == null) {
            return;
        }

        var left = node.left;
        var right = node.right;

        Mutate (left, node, true);

        if (parent == null) {
            node.right = null;
        }
        else {
            if (isLeftChild) {
                node.right = parent.right;
            }
            else {
                if (parent.right == null) {
                    node.right = null;
                }
                else {
                    node.right = parent.right.left;
                }
            }
        }
        Mutate (right, node, false);
    }

    public class BinaryTree {
        public int value;
        public BinaryTree left = null;
        public BinaryTree right = null;

        public BinaryTree(int value) {
            this.value = value;
        }
    }
}
