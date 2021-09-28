package main

// O(n.m) time | O(n.m) space
func LongestCommonSubsequence(s1 string, s2 string) []byte {
	lengths := make([][]int, len(s2)+1)
	for i := range lengths {
		lengths[i] = make([]int, len(s1)+1)
	}
	for i := 1; i < len(s2)+1; i++ {
		for j := 1; j < len(s1)+1; j++ {
			if s2[i-1] == s1[j-1] {
				lengths[i][j] = lengths[i-1][j-1] + 1
			} else {
				lengths[i][j] = max(lengths[i-1][j], lengths[i][j-1])
			}
		}
	}
	return buildSequence(lengths, s1)
}

func buildSequence(lengths [][]int, str string) []byte {
	sequence := make([]byte, 0)
	i := len(lengths) - 1
	j := len(lengths[0]) - 1
	for i != 0 && j != 0 {
		if lengths[i][j] == lengths[i-1][j] {
			i -= 1
		} else if lengths[i][j] == lengths[i][j-1] {
			j -= 1
		} else {
			sequence = append(sequence, str[j-1])
			i -= 1
			j -= 1
		}
	}
	return reverse(sequence)
}

func reverse(arr []byte) []byte {
	for i, j := 0, len(arr)-1; i < j; i, j = i+1, j-1 {
		arr[i], arr[j] = arr[j], arr[i]
	}
	return arr
}

func max(i, j int) int {
	if i > j {
		return i
	}
	return j
}
