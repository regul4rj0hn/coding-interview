using System;

/*
To find the solution we implement a variation of depth-first traversal that recursively keeps track of both the diameter and the height of a each subtree in the input binary tree, and continuously compute these diameters.
The length of the longest path of a binary tree that goes through the root is the sum of the heights of its left and right subtrees (left subtree height + right subtree height). 

The diameter of a binary tree can be calculated by taking the maximum of: 
 1) the maximum subtree diameter (max(left subtree diameter, right subtree diameter)); and 
 2) the length of the longest path that goes through the root (left subtree height + right subtree height).

Time : O(n) - Where N is the number of nodes in the binary tree
Space: O(h) - Where H is the height of the Binary Tree (at most H frames for the recursive call frames on the stack)
*/
public class Program {
    public int BinaryTreeDiameter (BinaryTree tree) {
        return GetTreeInfo (tree).Diameter;
    }

    public TreeInfo GetTreeInfo (BinaryTree tree) {
        if (tree == null) {
            return new TreeInfo(0, 0);
        }

        var leftTree = GetTreeInfo (tree.left);
        var rightTree = GetTreeInfo (tree.right);
        
        var longestPath  = leftTree.Height + rightTree.Height;
        var maxDiameter = Math.Max (leftTree.Diameter, rightTree.Diameter);
        var currentDiameter = Math.Max (longestPath, maxDiameter);
        var currentHeight = 1 + Math.Max (leftTree.Height, rightTree.Height);

        return new TreeInfo (currentDiameter, currentHeight);
    }

    public class TreeInfo {
        public TreeInfo (int diameter, int height) {
            Diameter = diameter;
            Height = height;
        }
        
        public int Diameter { get; set; }
        public int Height { get; set; }
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