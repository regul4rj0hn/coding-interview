using System;

/*
The recursive approach is a lot more intuitive in that we just swap the current node and call Invert recursively on both its left and right children nodes. The tree will be inversed when the calls return.
It's also better in space complexity if the tree is balanced, as we will have have recursive calls for the depth of the tree in the worst case.

Time : O(n) - Where N is the number of nodes on the input tree
Space: O(d) - Where D is the depth of the tree, to store the recursive call frames on the stack O(d) = O(log(n))
*/
public class Program {
    public static void InvertBinaryTree (BinaryTree tree) {
        if (tree == null) {
            return;
        }
        SwapLeftAndRight (tree);
        InvertBinaryTree (tree.left);
        InvertBinaryTree (tree.right);
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