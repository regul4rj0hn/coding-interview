using System;
using System.Collections.Generic;

/*
The best way to make BFS easy to solve is using a queue as an additional data structure:
 - We add the root of our graph to the queue, and we are going to loop through it until it is empty.
 - On each iteration, we pop the first item of the queue, add it to our output array, and add all its children to the queue.
 - In this way the queue will always contain the nodes from top to bottom from left to right of our graph, and the item in the front is what we need to add next to our output list.
 - When we get to the leaf nodes (no children), the queue will empty itself out as we add nodes to the output.

Time : O(v+e) - Where V is the length of the vertices in the graph and E is the number of edges connecting them
Space: O(v)   - Where V is the number of vertices that we need to return (notice that the queue will have at most V children nodes in it, so worst case we would have 2V => O(v))
*/
public class Program {
    public class Node {
        public string name;
        public List<Node> children = new List<Node> ();

        public Node (string name) {
            this.name = name;
        }

        public List<string> BreadthFirstSearch (List<string> array) {
            var queue = new Queue<Node> ();
            queue.Enqueue (this);
            
            while (queue.Count > 0) {
                var current = queue.Dequeue ();
                array.Add (current.name);
                current.children.ForEach (o => queue.Enqueue (o));
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
