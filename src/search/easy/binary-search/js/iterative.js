// O(log(n)) time | O(1) space
function binarySearch(array, target) {
    return binarySearchHelper(array, target, 0, array.length-1)
}

function binarySearchHelper(array, target, left, right) {
    while (left <= right) {
        const mid = Math.floor((left + right) / 2)
        const match = array[mid]
        if (target === match) {
            return mid
        } else if (target < match) {
            right = mid - 1
        } else {
            left = mid + 1
        }
    }
    return -1
}

exports.binarySearch = binarySearch
