using System;

/*
Average case: O(log(n)) time | O(log(n)) space
Worst case  : O(n)      time | O(n)      space
*/
public class Program {
    public static int FindClosestValueInBst (BST tree, int target) {
        return FindClosestValue (tree, target, tree.value);
    }

    private static int FindClosestValue (BST tree, int target, int closest) {
        if (Math.Abs(target - closest) > Math.Abs(target - tree.value)) {
            closest = tree.value;
        }
        if (tree.value > target && tree.left != null) {
            return FindClosestValue (tree.left, target, closest);
        } else if (tree.value < target && tree.right != null) {
            return FindClosestValue (tree.right, target, closest);
        } else {
            return closest;
        }
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