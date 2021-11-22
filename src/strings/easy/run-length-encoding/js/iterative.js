// O(n) time | O(n) space
function runLengthEncoding(string) {
    const encodedString = []
    let currentLength = 1

    for (let i = 1; i< string.length; i++) {
        const currentChar = string[i]
        const previousChar = string[i-1]

        if (currentChar !== previousChar || currentLength === 9) {
            encodedString.push(currentLength.toString())
            encodedString.push(previousChar)
            currentLength = 0
        }
        currentLength++
    }

    encodedString.push(currentLength.toString())
    encodedString.push(string[string.length - 1])

    return encodedString.join('')
}

exports.runLengthEncoding = runLengthEncoding;
