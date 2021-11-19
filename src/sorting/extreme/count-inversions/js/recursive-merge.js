// O(n.log(n)) time | O(n) space
function countInversions(array) {
    return countSubArrayInversions(array, 0, array.length)
}

function countSubArrayInversions(array, start, end) {
    if (end - start <= 1) {
        return 0
    }

    const mid = start + Math.floor((end - start) / 2)
    const leftInversions = countSubArrayInversions(array, start, mid)
    const rightInversions = countSubArrayInversions(array, mid, end)
    const mergeInversions = mergeSortAndCountInversions(array, start, mid, end)

    return leftInversions + rightInversions + mergeInversions
}

function mergeSortAndCountInversions(array, start, mid, end) {
    const sortedArray = []
    let left = start
    let right = mid
    let inversions = 0

    while (left < mid && right < end) {
        if (array[left] <= array[right]) {
            sortedArray.push(array[left])
            left++
        } else {
            inversions += mid - left
            sortedArray.push(array[right])
            right++
        }
    }
    
    sortedArray.push(...array.slice(left, mid), ...array.slice(right, end))
    for (let i = 0; i < sortedArray.length; i++) {
        const num = sortedArray[i]
        array[start + i] = num
    }

    return inversions
}

exports.countInversions = countInversions;
