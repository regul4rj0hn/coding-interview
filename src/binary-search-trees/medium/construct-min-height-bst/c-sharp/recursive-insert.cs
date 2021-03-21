using System;
using System.Collections.Generic;

/*
In order for the BST to have the smallest height possible, it needs to be balanced; in other words, it needs to have roughly the same number of nodes in its left subtree as in its right subtree.
The fact that the array is sorted is key to solving this problem in optimal time, otherwise we'd have to sort it.

Since the array is sorted, the value in the middle has roughly the same amount of elements to its left and to its right, which is key to keeping the tree balanced - and thus, min-height.

The general approach is to grab the middle element of the array, and make that element be the root node of the BST. Then, grab the middle element between the beginning of the array and the first middle element, and make that element be the root of the BST's left subtree; similarly, make the middle element between the end of the array and the first middle element be the root of the BST's right subtree. Continue this approach until you run out of elements in the array.
*/
public class Program {

    // This first approach makes use of the Insert method that comes with the provided BST implementation, thus the added O(log(n)) time complexity
    // O(n.log(n)) time | O(n) space
    public static BST MinHeightBst (List<int> array) {
        return ConstructMinHeightBst (array, null, 0, array.Count - 1);
    }

    private static BST ConstructMinHeightBst (List<int> array, BST bst, int start, int end) {
        if (end < start) {
            return null;
        }

        var mid = (start + end) / 2;
        var toAdd = array[mid];
        
        if (bst == null) {
            bst = new BST (toAdd);
        }
        else {
            bst.insert (toAdd);
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
