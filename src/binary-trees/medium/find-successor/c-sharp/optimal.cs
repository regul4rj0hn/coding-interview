using System;

public class Program
{
    // This is an input class. Do not edit.
    public class BinaryTree
    {
        public int value;
        public BinaryTree left = null;
        public BinaryTree right = null;
        public BinaryTree parent = null;

        public BinaryTree(int value)
        {
            this.value = value;
        }
    }

    // We can use the fact that each node has a pointer to its parent to solve this problem in O(h) time, where h is the height of the tree.
    // If the given node has a right subtree, then the next node in the in-order traversal is simply the leftmost node in that right subtree. 
    // If it doesn't have a right subtree, then we need to traverse up the tree looking for an ancestor of this node that contains the node in question in its left subtree. 
    // The first node that we find that contains the input node in its left subtree is the one that will be visited next in the in-order traversal. 
    // If we reach the root node, and the input node isn't in the root node's left subtree, then the input node has no successor, because it must be the rightmost node of entire tree.
    // O(h) time | O(1) space
    public BinaryTree FindSuccessor(BinaryTree tree, BinaryTree node)
    {
        return node.right != null ? GetLeftmostChild (node.right) : GetRightmostParent (node);
    }

    private BinaryTree GetLeftmostChild (BinaryTree node)
    {
        var currentNode = node;
        while (currentNode.left != null)
        {
            currentNode = currentNode.left;
        }

        return currentNode;
    }

    private BinaryTree GetRightmostParent (BinaryTree node)
    {
        var currentNode = node;
        while (currentNode.parent != null && currentNode.parent.right == currentNode)
        {
            currentNode = currentNode.parent;
        }
        return currentNode.parent;
    }
}
