// O(n) time | O(d) space
// where N is the total number of elements including sub-elements and D is the greatest depth of "special" arrays
function productSum(array, multiplier = 1) {
    let sum = 0
    for (const element of array) {
        if (Array.isArray(element)) {
            sum += productSum(element, multiplier + 1)
        } else {
            sum += element
        }
    }
    return sum * multiplier
}

exports.productSum = productSum;
