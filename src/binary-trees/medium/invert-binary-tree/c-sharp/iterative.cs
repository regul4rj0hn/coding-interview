using System;
using System.Collections.Generic;

/*
Same as with breath-first search, we initialize a queue going level by level, first adding the root.
On each iteration, we grab the current node, we swap its children sub-trees and add the nodes the queue (as they need to be reversed too).
When a node is a leaf (no children) the queue is going to start to empty up. When the queue is empty we've finished reversing the tree.

Time : O(n) - Where N is the number of nodes on the input tree
Space: O(n) - For the queue/list that stores the tree nodes that we are reversing (some point we will have all the leaf nodes of the tree on the queue) 
*/
public class Program {
    public static void InvertBinaryTree (BinaryTree tree) {
        var index = 0;
        var queue = new List<BinaryTree> ();
        queue.Add (tree);

        while (index < queue.Count) {
            var current = queue[index];
            index++;
            if (current == null) {
                continue;
            }
            SwapLeftAndRight (current);
            if (current.left != null) {
                queue.Add (current.left);
            }
            if (current.right != null) {
                queue.Add (current.right);
            }
        }
    }

    private static void SwapLeftAndRight (BinaryTree tree) {
        var left = tree.left;
        tree.left = tree.right;
        tree.right = left;
    }

    public class BinaryTree {
        public int value;
        public BinaryTree left;
        public BinaryTree right;

        public BinaryTree (int value) {
            this.value = value;
        }
    }
}