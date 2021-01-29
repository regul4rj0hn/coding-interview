using System;
using System.IO;

/*
Average case: O(n) time | O(h) space (when the tree is balanced)
Worst case  : O(n) time | O(n) space
Where N is the number of nodes, and H is the height of the Binary tree
*/
public class Program {
    public static int NodeDepths (BinaryTree root) {
        return CalculateDepth (root, 0);
    }

    private static int CalculateDepth(BinaryTree tree, int depth) {
        if (tree == null) {
            return 0;
        }
        return depth + CalculateDepth(tree.left, depth + 1) + CalculateDepth(tree.right, depth + 1);
    }

//    Dirty
//    private static int CalculateDepth (BinaryTree tree, int sum) {
//        int total = 0;
//        if (tree.left != null) {
//            total += CalculateDepth (tree.left, sum + 1);
//        }
//        if (tree.right != null) {
//            total += CalculateDepth (tree.right, sum + 1);
//        }
//        return total + sum;
//    }

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