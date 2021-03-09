using System;

/*
We create a helper method that is going to call itself recursively, and carry the min and max values of the tree and initialize them to Min and Max intigers respectively.

On each recursive call, we check if the current node is min > value >= max, if it is not then it's not a valid BST. If it is, then we need to check the left and right subtrees when they are not a leaf node, so we call the function recursively with the parameters depending on whether we are exploring the left or right subtrees and adjust min/max according to the rule above:
 - If we are exploring the left BST we call with tree.left, the minimum stays the same and we shrink the maximum to the current value (parent node has to be strictly greater than the left child's value)
 - If we are exploring the right BST we call with tree.right, we update the minimum to the current value, and the maximum stays the same.

If we pass all checks and finish exploring the tree, then it's a valid BST we return true.

Time : O(n) - Where N is the number of nodes of the tree (have to check them all)
Space: O(d) - Where D is the depth of the input tree, to store the frames of the recursive calls on the mem stack
*/
public class Program {
    public static bool ValidateBst (BST tree) {
        return ValidateBst (tree, int.MinValue, int.MaxValue);
    }
    
    private static bool ValidateBst (BST tree, int min, int max) {
        if (tree.value < min || tree.value >= max) {
            return false;
        }
        if (tree.left != null && !ValidateBst (tree.left, min, tree.value)) {
            return false;
        }
        if (tree.right != null && !ValidateBst (tree.right, tree.value, max)) {
            return false;
        }
        return true;
    }

    public class BST {
        public int value;
        public BST left;
        public BST right;

        public BST (int value) {
            this.value = value;
        }
    }
}
