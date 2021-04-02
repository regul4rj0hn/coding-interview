using System;

public class Program {
    public class BinaryTree {
        public int value;
        public BinaryTree left = null;
        public BinaryTree right = null;

        public BinaryTree(int value) {
            this.value = value;
        }
    }

    public class TreeInfo {
        public TreeInfo(bool isBalanced, int height) {
            IsBalanced = isBalanced;
            Height = height;
        }

        public bool IsBalanced { get; set; }
        public int Height { get; set; }
    }

    /*
    Time : O(n) - Where N is the number of nodes in the input tree 
    Space: O(h) - Where H is the height of tree, to store the frames on the stack for the recursive calls
    */
    public bool HeightBalancedBinaryTree(BinaryTree tree) {
        var treeInfo = GetTreeInfo(tree);
        return treeInfo.IsBalanced;
    }

    /*
    The height of a subtree can be determined by counting the number of edges between the current root of the subtree and the deep-most leaf node. 
    - A Binary Tree is balanced if the height difference between all of its node's left subtrees and right subtrees is less-than or equal to 1 .
    - The root node beeing balanced is not sufficient to claim that all the tree is balanced.
    - A leaf node is always balanced (zero eight on both subtrees).
    */
    private TreeInfo GetTreeInfo(BinaryTree node) {
        if (node == null) {
            return new TreeInfo (true, -1);
        }

        var leftSubtreeInfo = GetTreeInfo (node.left);
        var rightSubtreeInfo = GetTreeInfo (node.right);

        var isBalanced = leftSubtreeInfo.IsBalanced 
            && rightSubtreeInfo.IsBalanced
            && Math.Abs (leftSubtreeInfo.Height - rightSubtreeInfo.Height) <= 1;

        var height = Math.Max (leftSubtreeInfo.Height, rightSubtreeInfo.Height) + 1;

        return new TreeInfo (isBalanced, height);
    }
}
