using System;
using System.Collections.Generic;

public class Program {
    public class TrieNode {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode> ();
    }

    public class SuffixTrie {
        public TrieNode Root = new TrieNode ();
        private readonly char EndSymbol = '*';

        public SuffixTrie (string str) {
            PopulateSuffixTrieFrom (str);
        }

        // O(n^2) time | O(n^2) space
        // Where N is the length of the suffix that we are populating the tree with
        // N^2 space for the Dictionary structure to store the letters on the suffix and the children node relationships
        public void PopulateSuffixTrieFrom (string str) {
            for (int i = 0; i < str.Length; i++) {
                InsertSubstringAt (i, str);
            }
        }

        // O(m) time | O(1) space
        // Where M is the length of the input string suffix that we are searching for
        // The space analysis does not consider the Trie storage, just the search
        public bool Contains (string str) {
            var node = Root;
            foreach (char letter in str) {
                if (!node.Children.ContainsKey (letter)) {
                    return false;
                }
                node = node.Children[letter];
            }
            return node.Children.ContainsKey (EndSymbol);
        }

        private void InsertSubstringAt (int ix, string str) {
            var node = Root;
            for (int j = ix; j < str.Length; j++) {
                var letter = str[j];
                if (!node.Children.ContainsKey (letter)) {
                    var newNode = new TrieNode ();
                    node.Children.Add (letter, newNode);
                }
                node = node.Children[letter];
            }
            node.Children[EndSymbol] = null;
        }
    }
}