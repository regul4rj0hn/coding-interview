// O(n) time | O(1) space - where N is the length of the input string
// The input string will only have lowercase letters so 26 at most
function firstNonRepeatingCharacter(string) {
    const charFrequencies = {}

    for (const char of string) {
        if (!(char in charFrequencies)) {
            charFrequencies[char] = 0
        }
        charFrequencies[char]++
    }

    for (let i = 0; i < string.length; i++) {
        const char = string[i]
        if (charFrequencies[char] === 1) {
            return i
        }
    }

    return -1
}

exports.firstNonRepeatingCharacter = firstNonRepeatingCharacter;
