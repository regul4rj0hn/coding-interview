using System.Collections.Generic;
using System;

/*
To solve this problem with an optimal time complexity, realize that it's unnecessary to locate the right child of every node.
We can simply keep track of the pre-order-traversal position of the current node that needs to be created and try to insert that node as the left or right child of the relevant previously visited node instead. 
Since this tree is a BST, every node must satisfy the BST property; by keeping track of lower and upper bounds for node values, we should be able to determine if a node can be inserted as the left or right child of another node.
With this approach, we can solve the problem in linear time complexity.

Time : O(n)   - Where N is the length of the input list (and nodes in the tree).
Space: O(h+n) - Where H is the height of the BST, to store the frames on the recursive calls stack and N nodes of our output tree.
*/
public class Program
{
    public class BST
    {
        public int value;
        public BST left = null;
        public BST right = null;

        public BST (int value)
        {
            this.value = value;
        }
    }

    private class TreeInfo
    {
        public TreeInfo (int root)
        {
            Root = root;
        }
        public int Root { get; set; }
    }

    public BST ReconstructBst (List<int> preOrderTraversalValues)
    {
        var treeInfo = new TreeInfo(0);
        return ReconstructBstFromRange (int.MinValue, int.MaxValue, preOrderTraversalValues, treeInfo);
    }

    private BST ReconstructBstFromRange (
        int lowerBound,
        int upperBound,
        List<int> preOrderValues,
        TreeInfo info
    )
    {
        if (info.Root == preOrderValues.Count)
        {
            return null;
        }

        var rootValue = preOrderValues[info.Root];
        if (rootValue < lowerBound || rootValue >= upperBound)
        {
            return null;
        }

        info.Root += 1;
        var leftSubtree = ReconstructBstFromRange (lowerBound, rootValue, preOrderValues, info);
        var rightSubtree = ReconstructBstFromRange (rootValue, upperBound, preOrderValues, info);

        var bst = new BST (rootValue);
        bst.left = leftSubtree;
        bst.right = rightSubtree;

        return bst;
    }
}
