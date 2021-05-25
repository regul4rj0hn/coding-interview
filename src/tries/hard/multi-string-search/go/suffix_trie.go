package main

type ModifiedSuffixTrie map[byte]ModifiedSuffixTrie

// O(b^2 + n.s) time | O(b^2 + n) space| Where :
// B is the length of the big string
// N is the number of small strings
// S is the length of the longest small string
func MultiStringSearch(bigString string, smallStrings []string) []bool {
	trie := NewTrie(bigString)
	output := make([]bool, len(smallStrings))
	for i, str := range smallStrings {
		output[i] = trie.Contains(str)
	}
	return output
}

func NewTrie(str string) ModifiedSuffixTrie {
	trie := ModifiedSuffixTrie{}
	for i := range str {
		trie.Add(str, i)
	}
	return trie
}

func (trie ModifiedSuffixTrie) Add(str string, start int) {
	node := trie
	for i := start; i < len(str); i++ {
		letter := str[i]
		if _, found := node[letter]; !found {
			node[letter] = ModifiedSuffixTrie{}
		}
		node = node[letter]
	}
}

func (trie ModifiedSuffixTrie) Contains(str string) bool {
	node := trie
	for i := range str {
		letter := str[i]
		if _, found := node[letter]; !found {
			return false
		}
		node = node[letter]
	}
	return true
}
