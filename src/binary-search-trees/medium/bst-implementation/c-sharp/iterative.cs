using System;

/*
Average case: O(log(n)) time | O(1) space
Worst case  : O(n)      time | O(1) space
Where N is the number of nodes in the tree
No recursive calls, so space is constant
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
            BST currentNode = this;
            while (true) {
                if (value < currentNode.value) {
                    if (currentNode.left == null) {
                        BST node = new BST (value);
                        currentNode.left = node;
                        break;
                    } else {
                        currentNode = currentNode.left;
                    }
                }
                else {
                    if (currentNode.right == null) {
                        BST node = new BST (value);
                        currentNode.right = node;
                        break;
                    } else {
                        currentNode = currentNode.right;
                    }
                }
            }
            return this;
        }

        public bool Contains (int value) {
            BST currentNode = this;
            while (currentNode != null) {
                if (value < currentNode.value) {
                    currentNode = currentNode.left;
                }
                else if (value > currentNode.value) {
                    currentNode = currentNode.right;
                }
                else {
                    return true;
                }
            }
            return false;
        }

        public BST Remove (int value) {
            Remove (value, null);
            return this;
        }

        private void Remove (int value, BST parent) {
            BST currentNode = this;
            while (currentNode != null) {
                if (value < currentNode.value) {
                    parent = currentNode;
                    currentNode = currentNode.left;
                }
                else if (value > currentNode.value) {
                    parent = currentNode;
                    currentNode = currentNode.right;
                }
                else if (currentNode.left != null && currentNode.right != null) {
                    currentNode.value = currentNode.right.GetMinimumValue ();
                    currentNode.right.Remove (currentNode.value, currentNode);
                }
                else if (parent == null && left != null) {
                    currentNode.value = currentNode.left.value;
                    currentNode.right = currentNode.left.right;
                    currentNode.left = currentNode.left.left;
                }
                else if (right != null) {
                    currentNode.value = currentNode.right.value;
                    currentNode.left = currentNode.right.left;
                    currentNode.right = currentNode.right.right;
                }
                else if (parent != null && parent.left == currentNode) {
                    parent.left = currentNode.left != null ? currentNode.left : currentNode.right;
                }
                else if (parent != null && parent.right == currentNode) {
                    parent.right = currentNode.left != null ? currentNode.left : currentNode.right;
                }
                break;
            }
        }

        private int GetMinimumValue () {
            return left == null ? value : left.GetMinimumValue ();
        }
    }
}