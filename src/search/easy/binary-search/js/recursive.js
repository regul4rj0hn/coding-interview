// O(log(n)) time | O(log(n)) space
function binarySearch(array, target) {
    return binarySearchHelper(array, target, 0, array.length - 1)
}

function binarySearchHelper(array, target, left, right) {
    if (left > right) return -1

    const mid = Math.floor((left + right) / 2)
    const match = array[mid];
    if (target === match) {
        return mid
    } else if (target < match) {
        return binarySearchHelper(array, target, left, mid - 1)
    } else {
        return binarySearchHelper(array, target, mid + 1, right)
    }
}

exports.binarySearch = binarySearch
