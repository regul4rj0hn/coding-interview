using System;

/*
Average case: O(log(n)) time | O(log(n)) space
Worst case  : O(n)      time | O(d)      space
Where N is the number of nodes in the tree and D is the depth of the tree
*/
public class Program {
    public class BST {
        public int value;
        public BST left;
        public BST right;

        public BST (int value) {
            this.value = value;
        }

        public BST Insert (int value) {
            if (value < this.value) {
                if (left == null) {
                    BST node = new BST (value);
                    left = node;
                }
                else {
                    left.Insert (value);
                }
            }
            else {
                if (right == null) {
                    BST node = new BST (value);
                    right = node;
                }
                else {
                    right.Insert (value);
                }
            }
            return this;
        }

        public bool Contains (int value) {
            if (this.value == value) {
                return true;
            }
            if (this.value > value && this.left != null) {
                return left.Contains (value);
            }
            if (this.value < value && this.right != null) {
                return right.Contains (value);
            }
            return false;
        }

        // Grab the smallest, left-most value on the right sub-tree of our target node to replace
        public BST Remove (int value) {
            Remove(value, null);
            return this;
        }

        private void Remove (int value, BST parent) {
            if (value < this.value && left != null) {
                left.Remove (value, this);
            }
        }

        private int GetMinimumValue () {
            return left == null ? value : left.GetMinimumValue ();
        }
    }
}