using System;

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

    public class TreeInfo
    {
        public TreeInfo (int visitedCount, int lastValue)
        {
            NodesVisitedCount = visitedCount;
            LastVisitedValue = lastValue;
        }

        public int NodesVisitedCount { get; set; }
        public int LastVisitedValue { get; set; }
    }

    // To solve the problem in the optimal time complexity, we need to perform a reverse in-order traversal.
    // Since the result traversal will be the nodes of the tree in descending order, we can simply stop traversing at the Kth node (recursive call) and return it.
    // O(h + k) time | O(h) space - where H is the height of the tree and K is the input parameter
    public int FindKthLargestValueInBst (BST tree, int k)
    {
        var treeInfo = new TreeInfo (0, -1);
        ReverseInOrderTraverse (tree, k, treeInfo);
        return treeInfo.LastVisitedValue;
    }

    private void ReverseInOrderTraverse (BST node, int k, TreeInfo info)
    {
        if (node == null || info.NodesVisitedCount >= k)
        {
            return;
        }

        ReverseInOrderTraverse (node.right, k, info);

        if (info.NodesVisitedCount < k)
        {
            info.NodesVisitedCount += 1;
            info.LastVisitedValue = node.value;
            ReverseInOrderTraverse (node.left, k, info);
        }
    }
}

