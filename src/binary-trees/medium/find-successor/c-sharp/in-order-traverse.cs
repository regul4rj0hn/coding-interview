using System;
using System.Collections.Generic;

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

    // General approach is to start by performing an in-order traversal of the tree and store the nodes in an list.
    // Then traverse the list of nodes of the in-order traverse and, once that we find the input node, return the node that comes immediately after it.
    // O(n) time | O(n) space - where N is the number of nodes in the tree
    public BinaryTree FindSuccessor (BinaryTree tree, BinaryTree node)
    {
        var inOrder = new List<BinaryTree> ();
        InOrderTraverse (tree, inOrder);

        for (var i = 0; i < inOrder.Count; i++)
        {
            var currentNode = inOrder[i];

            if (currentNode != node)
            {
                continue;
            }

            if (i == inOrder.Count - 1)
            {
                return null;
            }

            return inOrder[i + 1];
        }

        return null;
    }

    private void InOrderTraverse (BinaryTree node, List<BinaryTree> order)
    {
        if (node == null)
        {
            return;
        }
        InOrderTraverse (node.left, order);
        order.Add (node);
        InOrderTraverse (node.right, order);
    }
}
