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
                } else {
                    left.Insert (value);
                }
            } else {
                if (right == null) {
                    BST node = new BST (value);
                    right = node;
                } else {
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

        
        public BST Remove (int value) {
            Remove (value, null);
            return this;
        }

        // helper remove method to keep track of the parent of the current node
        private void Remove (int value, BST parent) {
            // find the value to remove in the left sub-tree of the current node
            if (value < this.value && left != null) {
                left.Remove (value, this);
            }
            // find the value to remove in the right sub-tree of the current node
            else if (value > this.value && right != null) {
                right.Remove (value, this);
            }
            // the current node value is not less-than or bigger than the target 
            // if the current node has two children, grab the smallest left-most
            // value on the right sub-tree and attempt to remove that node
            else if (left != null && right != null) {
                this.value = right.GetMinimumValue ();
                right.Remove (this.value, this);
            }
            // root node that has only a left child, shift the left sub-tree up
            else if (parent == null && left != null) {
                this.value = left.value;
                right = left.right;
                left = left.left;
            }
            // if it has only a right child, shift the right sub-tree up
            else if (right != null) {
                this.value = right.value;
                left = right.left;
                right = right.right;
            }
            // if current node is not the root and is the left child of some parent
            // if the left child of the current node is not null, shift it up and 
            // assign it to parent.left, otherwise assign right child
            else if (parent != null && parent.left == this) {
                parent.left = left != null ? left : right;
            }
            // if current node is not the root and is the right child of some parent
            // if the left child of the current node is not null, shift it up and 
            // assign it to parent.right, otherwise assign right child
            else if (parent != null && parent.right == this) {
                parent.right = left != null ? left : right;
            }
        }

        // Find the smallest, left-most value of the current sub-tree
        private int GetMinimumValue () {
            return left == null ? value : left.GetMinimumValue ();
        }
    }
}