using System;

/*
Realize that we are dealing with a graph problem, specifically a tree where every node points to one parent node - so we will have to traverse the tree "upwards".
With that in mind, we need to first figure out a way to bring both nodes to the same depth level, so that we can start iterating upwards in the tree until we find the youngest common ancestor.
One way to do so is to count the number of levels (calculate the depth) between our two input nodes and the root (topAncestor), and then bring the node that's deeper to the level of the other node:
 - If we have nodes A and B, where B is deeper in the tree than A
 - Calculate depth(B) - depth(A) and that's the number of ancestor nodes we need to move up the tree for B
 - Once they are leveled, iterate upwards until we land on the same ancestor.

Time : O(d) - Where D is the depth of the lowest descendant of the input ancestral tree
Space: O(1) - No extra data structures, traverse the tree in place
*/
public class Program {
    public static AncestralTree GetYoungestCommonAncestor (
        AncestralTree topAncestor,
        AncestralTree descendantOne,
        AncestralTree descendantTwo
    ) {
        var depthOne = GetDescendantDepth (descendantOne, topAncestor);
        var depthTwo = GetDescendantDepth (descendantTwo, topAncestor);

        return depthOne > depthTwo ? BacktrackTree (descendantOne, descendantTwo, depthOne - depthTwo)
                : BacktrackTree (descendantTwo, descendantOne, depthTwo - depthOne);
    }

    private static int GetDescendantDepth (
        AncestralTree descendant,
        AncestralTree topAncestor
    ) {
        var depth = 0;

        while (descendant != topAncestor) {
            depth++;
            descendant = descendant.ancestor;
        }

        return depth;
    }
    
    private static AncestralTree BacktrackTree (
        AncestralTree lowerDescendant,
        AncestralTree higherDescendant,
        int diff
    ) {
        while (diff  > 0) {
            lowerDescendant = lowerDescendant.ancestor;
            diff--;
        }
        while (lowerDescendant != higherDescendant) {
            lowerDescendant = lowerDescendant.ancestor;
            higherDescendant = higherDescendant.ancestor;
        }

        return lowerDescendant;
    }

    public class AncestralTree {
        public char name;
        public AncestralTree ancestor;

        public AncestralTree (char name) {
            this.name = name;
            this.ancestor = null;
        }

        // This method is for testing only.
        public void AddAsAncestor (AncestralTree[] descendants) {
            foreach (AncestralTree descendant in descendants) {
                descendant.ancestor = this;
            }
        }
    }
}
