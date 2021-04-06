using System;
using System.Collections.Generic;

/*
For every node in a Binary Tree, there are four options for the max path sum that includes its value: 
 - the node's value alone, 
 - the node's value plus the max path sum of its left subtree, 
 - the node's value plus the max path sum of its right subtree, 
 - the node's value plus the max path sum of both its subtrees.

We can use a recursive algorithm that computes each node's max path sum and uses it to compute its parents' nodes' max path sums to approach the solution.
Keeping in mind that we cannot have a path going through a node _and_ through both its subtrees, as well as that node's parent node (fourth rule) as that would not be a valid path (a node can only be connected to two other nodes)
To get arround it, we compute a bunch of things at each node and track our maximum sum for the current branch and the complete path on a list (or tupple) data structure, so on each node we would need:
 - the maximum sum using the current node and only one branch (instead of both children that creates incorrect paths)
 - the maximum sum as if we were on a root node and were to use both left and right sub-trees (which means we can't use its parent node on the path)
 - the running max path sum (computed maximum for the above)

We return the last recursive call's max sum.
*/
public class Program {
    public static int MaxPathSum (BinaryTree tree) {
        var maxSums = FindMaxSums (tree);
        return maxSums[1];
    }

    // O(n) time | O(log(n)) space
    // where N is the number of nodes of the binary tree
    // the list we return has constant space complexity, the log(n) space is for the frames on the recursive call stack (height of the binary tree)
    private static List<int> FindMaxSums (BinaryTree tree) {
        if (tree == null) {
            return new List<int>() { 0, int.MinValue };
        }

        var leftMaxSums = FindMaxSums (tree.left);
        var leftMaxBranchSum = leftMaxSums[0];
        var leftMaxPathSum = leftMaxSums[1];

        var rightMaxSums = FindMaxSums (tree.right);
        var rightMaxBranchSum = rightMaxSums[0];
        var rightMaxPathSum = rightMaxSums[1];

        var maxChildBranchSum = Math.Max (leftMaxBranchSum, rightMaxBranchSum);
        var maxBranchSum = Math.Max (maxChildBranchSum + tree.value, tree.value);
        var maxSumAsRootNode = Math.Max (leftMaxBranchSum + tree.value + rightMaxBranchSum, maxBranchSum);
        var maxPathSum = Math.Max (leftMaxPathSum, Math.Max (rightMaxPathSum, maxSumAsRootNode));

        return new List<int>() { maxBranchSum, maxPathSum };
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
