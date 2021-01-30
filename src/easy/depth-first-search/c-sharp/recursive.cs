using System;
using System.Collections.Generic;

/*
O(V+e) time | O(V) space (because of the array that we return and the max-frames for the recursive calls)
Where V is the number of Vertex, and e is the number of Edges in the graph
*/
public class Program {
    public class Node {
        public string name;
        public List<Node> children = new List<Node> ();

        public Node (string name) {
            this.name = name;
        }

        public List<string> DepthFirstSearch (List<string> array) {
            array.Add (name);
            foreach (Node n in children) {
                n.DepthFirstSearch (array);
            }
            return array;
        }

        public Node AddChild (string name) {
            Node child = new Node (name);
            children.Add (child);
            return this;
        }
    }
}