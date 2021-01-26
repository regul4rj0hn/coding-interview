using System;

/*
Average case: O(log(n)) time | O(1) space
Worst case  : O(n)      time | O(1) space
*/
public class Program {
    public static int FindClosestValueInBst (BST tree, int target) {
        int closest = tree.value;
        int node = tree.value;

        while (closest != target && tree != null) {
            if (Math.Abs (target - closest) > Math.Abs (target - node)) {
                closest = node;
            }

            if (node > target && tree.left != null) {
                tree = tree.left;
            } else if (node < target && tree.right != null) {
                tree = tree.right;
            } else {
                tree = null;
            }

            node = tree != null ? tree.value : 0;
        }

        return closest;
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