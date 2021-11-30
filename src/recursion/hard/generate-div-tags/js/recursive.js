function generateDivTags(numberOfTags) {
    const matchedTags = []
    generateDivTagsFromPrefix(numberOfTags, numberOfTags, '', matchedTags)
    return matchedTags
}

function generateDivTagsFromPrefix(opening, closing, prefix, output) {
    if (opening > 0) {
        const newPrefix = prefix + '<div>'
        generateDivTagsFromPrefix(opening - 1, closing, newPrefix, output)
    }
    if (opening < closing) {
        const newPrefix = prefix + '</div>'
        generateDivTagsFromPrefix(opening, closing - 1, newPrefix, output)
    }
    if (closing === 0) {
        output.push(prefix)
    }
}

exports.generateDivTags = generateDivTags;
