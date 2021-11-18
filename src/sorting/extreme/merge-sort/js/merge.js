// O(n.log(n)) time | O(n) space
function mergeSort(array) {
    if (array.length <= 1) {
        return array
    }
    const auxArray = array.slice();
    mergeSortHelper(array, 0, array.length - 1, auxArray)
    return array
}

function mergeSortHelper(mainArray, start, end, auxArray) {
    if (start === end) {
        return
    }
    const mid = Math.floor((start + end) / 2)
    mergeSortHelper(auxArray, start, mid, mainArray)
    mergeSortHelper(auxArray, mid + 1, end, mainArray)
    merge(mainArray, start, mid, end, auxArray)
}

function merge(mainArray, start, mid, end, auxArray) {
    let k = start
    let i = start
    let j = mid + 1
    while (i <= mid && j <= end) {
        if (auxArray[i] <= auxArray[j]) {
            mainArray[k++] = auxArray[i++]
        } else {
            mainArray[k++] = auxArray[j++]
        }
    }
    while (i <= mid) {
        mainArray[k++] = auxArray[i++]
    }
    while (j <= end) {
        mainArray[k++] = auxArray[j++]
    }
}

exports.mergeSort = mergeSort;
