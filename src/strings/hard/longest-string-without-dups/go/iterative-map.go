package main

type substring struct {
	start int
	end   int
}

func (ss substring) length() int {
	return ss.end - ss.start
}

func LongestSubstringWithoutDuplication(str string) string {
	lastSeen := map[rune]int{}
	longest := substring{0, 1}
	startIdx := 0
	for i, char := range str {
		if seenIdx, found := lastSeen[char]; found && startIdx < seenIdx+1 {
			startIdx = seenIdx + 1
		}
		if longest.length() < i+1-startIdx {
			longest = substring{startIdx, i + 1}
		}
		lastSeen[char] = i
	}
	return str[longest.start:longest.end]
}
