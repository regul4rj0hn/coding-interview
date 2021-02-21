using System;

public class Program {
    public class DoublyLinkedList {
        public Node Head;
        public Node Tail;

        // O(1) time | O(1) space
        public void SetHead (Node node) {
            if (Head == null) {
                Head = node;
                Tail = node;
            } else {
                InsertBefore (Head, node);
            }
        }

        // O(1) time | O(1) space
        public void SetTail (Node node) {
            if (Tail == null) {
                SetHead (node);
            } else {
                InsertAfter (Tail, node);
            }
        }

        // O(1) time | O(1) space
        public void InsertBefore (Node node, Node nodeToInsert) {
            if (nodeToInsert == Head && nodeToInsert == Tail) {
                return;
            }
            Remove (nodeToInsert);
            nodeToInsert.Prev = node.Prev;
            nodeToInsert.Next = node;
            if (node.Prev == null) {
                Head = nodeToInsert;
            } else {
                node.Prev.Next = nodeToInsert;
            }
            node.Prev = nodeToInsert;
        }

        // O(1) time | O(1) space
        public void InsertAfter (Node node, Node nodeToInsert) {
            if (nodeToInsert == Head && nodeToInsert == Tail) {
                return;
            }
            Remove (nodeToInsert);
            nodeToInsert.Prev = node;
            nodeToInsert.Next = node.Next;
            if (node.Next == null) {
                Tail = nodeToInsert;
            } else {
                node.Next.Prev = nodeToInsert;
            }
            node.Next = nodeToInsert;
        }

        // O(n) time | O(1) space
        // Where N is the position on the list where we want to insert the node 
        public void InsertAtPosition (int position, Node nodeToInsert) {
            if (position == 1) {
                SetHead (nodeToInsert);
            } else {
                var node = Head;
                var current = 1;
                while (node != null && current++ != position) {
                    node = node.Next;
                }
                if (node != null) {
                    InsertBefore (node, nodeToInsert);
                } else {
                    SetTail (nodeToInsert);
                }
            }
        }

        // O(n) time | O(1) space
        // Where N is the full length of the list (need to search for all matches)
        public void RemoveNodesWithValue (int value) {
            var node = Head;
            while (node != null) {
                var toRemove = node;
                node = node.Next;
                if (toRemove.Value == value) {
                    Remove (toRemove);
                }
            }
        }

        // O(1) time | O(1) space
        public void Remove (Node node) {
            if (node == Head) {
                Head = Head.Next;
            }
            if (node == Tail) {
                Tail = Tail.Prev;
            }
            RemoveNodeBindings (node);
        }

        // O(n) time | O(1) space
        // Where N is the number of nodes in the list (worst case node is not on the list)
        public bool ContainsNodeWithValue (int value) {
            var node = Head;
            while (node != null && node.Value != value) {
                node = node.Next;
            }
            return node != null;
        }

        // O(1) time | O(1) space
        private void RemoveNodeBindings (Node node) {
            if (node.Prev != null) {
                node.Prev.Next = node.Next;
            }
            if (node.Next != null) {
                node.Next.Prev = node.Prev;
            }
            node.Prev = null;
            node.Next = null;
        }
    }

    public class Node {
        public int Value;
        public Node Prev;
        public Node Next;

        public Node (int value) {
            this.Value = value;
        }
    }
}