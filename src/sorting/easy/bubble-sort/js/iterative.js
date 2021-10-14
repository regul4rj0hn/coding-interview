// O(n^2) time | O(1) space
function bubbleSort(array) {
    let isSorted = false
    let count = 0
    while (!isSorted) {
        isSorted = true
        for (let i = 0; i < array.length - 1 - count; i++) {
            if (array[i] > array[i + 1]) {
                swap(i, i+1, array)
                isSorted = false
            }
        }
        count++
    }
    return array
}

function swap(i, j, array) {
    const tmp = array[j]
    array[j] = array[i]
    array[i] = tmp
}

exports.bubbleSort = bubbleSort;
