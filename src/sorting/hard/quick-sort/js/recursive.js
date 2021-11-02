// Avrge: O(n.log(n)) time | O(log(n)) space
// Worst: O(n^2)      time | O(log(n)) space
function quickSort(array) {
    quickSortHelper(array, 0, array.length - 1)
    return array
}

function quickSortHelper(array, iStart, iEnd) {
    if (iStart >= iEnd) {
        return
    }
    const iPivot = iStart
    let iLeft = iStart + 1
    let iRight = iEnd
    while (iRight >= iLeft) {
        if (array[iLeft] > array[iPivot] && array[iRight] < array[iPivot]) {
            swap(iLeft, iRight, array)
        }
        if (array[iLeft] <= array[iPivot]) {
            iLeft++
        }
        if (array[iRight] >= array[iPivot]) {
            iRight--
        }
    }
    swap(iPivot, iRight, array)
    const bIsLeftSubarraySmaller = iRight - 1 - iStart < iEnd - (iRight + 1)
    if (bIsLeftSubarraySmaller) {
        quickSortHelper(array, iStart, iRight - 1)
        quickSortHelper(array, iRight + 1, iEnd)
    } else {
        quickSortHelper(array, iRight + 1, iEnd)
        quickSortHelper(array, iStart, iRight -1)
    }
}

function swap(i, j, array) {
    let tmp = array[j]
    array[j] = array[i]
    array[i] = tmp
}

exports.quickSort = quickSort;
