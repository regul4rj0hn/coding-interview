using System;
using System.Collections.Generic;

/*
  Time: O(n)
  Space: O(n)
  Where N is the number of nodes in the Binary Tree
*/
public class Program {
    public class BinaryTree {
        public int value;
        public BinaryTree left;
        public BinaryTree right;

        public BinaryTree (int value) {
            this.value = value;
            this.left = null;
            this.right = null;
        }
    }

    public static List<int> BranchSums (BinaryTree root) {
        var ret = new List<int> ();
        SumBranch (root, 0, ret);
        return ret;
    }

    private static void SumBranch (BinaryTree tree, int sum, List<int> ret) {
        if (tree.left == null && tree.right == null) {
            ret.Add (sum + tree.value);
        }
        if (tree.left != null) {
            SumBranch (tree.left, sum + tree.value, ret);
        }
        if (tree.right != null) {
            SumBranch (tree.right, sum + tree.value, ret);
        }
    }
}