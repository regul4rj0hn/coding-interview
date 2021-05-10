package main

func IsPalindrome(str string) bool {
	for i := 0; i < len(str); i++ {
		if j := len(str) - i - 1; str[i] != str[j] {
			return false
		}
	}
	return true
}
