package main

type Trie struct {
	children map[byte]Trie
	word     string
}

// O(n.s + b.s) time | O(ns) space | Where :
// B is the length of the big string
// N is the number of small strings
// S is the length of the longest small string
func MultiStringSearch(bigString string, smallStrings []string) []bool {
	trie := Trie{children: map[byte]Trie{}}
	for _, str := range smallStrings {
		trie.Add(str)
	}
	containedStrings := map[string]bool{}
	for i := range bigString {
		findStringsIn(bigString, i, trie, containedStrings)
	}
	output := make([]bool, len(smallStrings))
	for i, str := range smallStrings {
		output[i] = containedStrings[str]
	}
	return output
}

func findStringsIn(str string, start int, trie Trie, strings map[string]bool) {
	current := trie
	for i := start; i < len(str); i++ {
		ch := str[i]
		if _, found := current.children[ch]; !found {
			break
		}
		current = current.children[ch]
		if end, found := current.children['*']; found {
			strings[end.word] = true
		}
	}
}

func (t Trie) Add(word string) {
	current := t
	for i := range word {
		letter := word[i]
		if _, found := current.children[letter]; !found {
			current.children[letter] = Trie{
				children: map[byte]Trie{},
			}
		}
		current = current.children[letter]
	}
	current.children['*'] = Trie{
		children: map[byte]Trie{},
		word:     word,
	}
}
