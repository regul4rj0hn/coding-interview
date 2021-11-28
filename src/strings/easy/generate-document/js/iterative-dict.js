// O(n + m) time | O(c) space
// where N is the number of chars, m is the length of the document, and c is the number of unique chars in the string
function generateDocument(characters, document) {
    const charCounts = {}
    for (const char of characters) {
        if (!(char in charCounts)) {
            charCounts[char] = 0
        }
        charCounts[char]++
    }

    for (const char of document) {
        if (!(char in charCounts) || charCounts[char] === 0) {
            return false
        }
        charCounts[char]--
    }

    return true
}

exports.generateDocument = generateDocument;
