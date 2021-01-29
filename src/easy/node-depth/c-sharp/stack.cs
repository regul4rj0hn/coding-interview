using System;
using System.Collections.Generic;

/*
Average case: O(n) time | O(h) space (when the tree is balanced)
Worst case  : O(n) time | O(n) space ("single-branch" tree stack space)
Where N is the number of nodes, and H is the height of the Binary tree
*/
public class Program {
    public static int NodeDepths (BinaryTree root) {
        int sum = 0;
        Stack<TreeLevel> store = new Stack<TreeLevel> ();

        store.Push (new TreeLevel (root, 0));

        while (store.Count > 0) {
            TreeLevel current = store.Pop ();
            BinaryTree node = current.root;
            int depth = current.depth;

            if (node != null) {
                sum += depth;
                store.Push (new TreeLevel (node.left, depth + 1));
                store.Push (new TreeLevel (node.right, depth + 1));
            }
        }

        return sum;
    }

    public class TreeLevel {
        public BinaryTree root;
        public int depth;

        public TreeLevel (BinaryTree root, int depth) {
            this.root = root;
            this.depth = depth;
        }
    }

    public class BinaryTree {
        public int value;
        public BinaryTree left;
        public BinaryTree right;

        public BinaryTree (int value) {
            this.value = value;
            left = null;
            right = null;
        }
    }
}