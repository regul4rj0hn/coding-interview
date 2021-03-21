using System;
using System.Collections.Generic;

public class Program
{
    // Instead of using the Insert method on the BST class, we pass down the the current BST node, and compare it to the value that we are trying to insert
    // This result in a constant time operation, thus improving the time complexity compared to recursive-insert
    // O(n) time | O(n) space
    public static BST MinHeightBst (List<int> array)
    {
        return ConstructMinHeightBst (array, null, 0, array.Count - 1);
    }

    private static BST ConstructMinHeightBst (List<int> array, BST bst, int start, int end)
    {
        if (end < start)
        {
            return null;
        }

        var mid = (start + end) / 2;
        var bstNode = new BST (array[mid]);

        if (bst == null)
        {
            bst = bstNode;
        }
        else
        {
            if (array[mid] < bst.value)
            {
                bst.left = bstNode;
                bst = bst.left;
            }
            else
            {
                bst.right = bstNode;
                bst = bst.right;
            }
        }

        ConstructMinHeightBst (array, bst, start, mid - 1);
        ConstructMinHeightBst (array, bst, mid + 1, end);

        return bst;
    }

    public class BST
    {
        public int value;
        public BST left;
        public BST right;

        public BST(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }

        public void insert(int value)
        {
            if (value < this.value)
            {
                if (left == null)
                {
                    left = new BST(value);
                }
                else
                {
                    left.insert(value);
                }
            }
            else
            {
                if (right == null)
                {
                    right = new BST(value);
                }
                else
                {
                    right.insert(value);
                }
            }
        }
    }
}
