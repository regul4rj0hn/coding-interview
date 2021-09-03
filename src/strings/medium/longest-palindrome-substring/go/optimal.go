package main

type substring struct {
	left  int
	right int
}

func (ss substring) length() int {
	return ss.right - ss.left
}

// O(n^2) time | O(n) space
func LongestPalindromicSubstring(str string) string {
	result := substring{0, 1}
	for i := 1; i < len(str); i++ {
		odd := getLongestPalindromeFrom(str, i-1, i+1)
		even := getLongestPalindromeFrom(str, i-1, i)
		longest := even
		if odd.length() > even.length() {
			longest = odd
		}
		if longest.length() > result.length() {
			result = longest
		}
	}
	return str[result.left:result.right]
}

func getLongestPalindromeFrom(str string, left, right int) substring {
	for left >= 0 && right < len(str) {
		if str[left] != str[right] {
			break
		}
		left -= 1
		right += 1
	}
	return substring{left + 1, right}
}
