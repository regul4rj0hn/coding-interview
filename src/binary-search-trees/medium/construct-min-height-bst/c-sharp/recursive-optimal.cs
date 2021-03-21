using System;
using System.Collections.Generic;

public class Program
{
    // Same approach and time/space complexity as the recursive-better solution
    // Gets rid of the BST parameter on the helper method, instead declaring the return tree on the first iteration
    // Recursively adds the left and right subtrees to it, which also cleans-up unnecessary conditionals.
    // O(n) time | O(n) space
    public static BST MinHeightBst (List<int> array)
    {
        return ConstructMinHeightBst (array, 0, array.Count - 1);
    }

    private static BST ConstructMinHeightBst(List<int> array, int start, int end)
    {
        if (end < start)
        {
            return null;
        }

        var mid = (start + end) / 2;
        var bst = new BST(array[mid]);

        bst.left = ConstructMinHeightBst (array, start, mid - 1);
        bst.right = ConstructMinHeightBst (array, mid + 1, end);

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
