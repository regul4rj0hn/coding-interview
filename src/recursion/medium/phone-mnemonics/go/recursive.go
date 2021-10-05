package main

// O(4^n.n) time | O(4^n.n) space
// where N is the length of the input phone number
func PhoneNumberMnemonics(phoneNumber string) []string {
	currentMnemonic := make([]byte, len(phoneNumber))
	for i := range currentMnemonic {
		currentMnemonic[i] = '0'
	}

	mnemonicsFound := make([]string, 0)
	phoneNumberMnemonicsHelper(0, phoneNumber, currentMnemonic, &mnemonicsFound)
	return mnemonicsFound
}

func phoneNumberMnemonicsHelper(i int, phone string, mnemonic []byte, output *[]string) {
	if i == len(phone) {
		current := string(mnemonic)
		*output = append(*output, current)
	} else {
		digit := phone[i]
		chars := DigitChars[digit]
		for _, letter := range chars {
			mnemonic[i] = letter
			phoneNumberMnemonicsHelper(i+1, phone, mnemonic, output)
		}
	}
}

var DigitChars = map[byte][]byte{
	'0': {'0'},
	'1': {'1'},
	'2': {'a', 'b', 'c'},
	'3': {'d', 'e', 'f'},
	'4': {'g', 'h', 'i'},
	'5': {'j', 'k', 'l'},
	'6': {'m', 'n', 'o'},
	'7': {'p', 'q', 'r', 's'},
	'8': {'t', 'u', 'v'},
	'9': {'w', 'x', 'y', 'z'},
}
