function caesarCipherEncryptor(string, key) {
    const output = []
    const modKey = key % 26
    const alphabet = 'abcdefghijklmnopqrstuvwxyz'.split('')
    for (const letter of string) {
        output.push(encode(letter, modKey, alphabet))
    }
    return output.join('')
}

function encode(letter, key, alphabet) {
    const code = alphabet.indexOf(letter) + key
    return alphabet[code % 26]
}

exports.caesarCipherEncryptor = caesarCipherEncryptor;
