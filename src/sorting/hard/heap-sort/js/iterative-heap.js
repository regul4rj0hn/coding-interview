// O(n.log(n)) time | O(1) space
function heapSort(array) {
    buildMaxHeap(array)
    for (let i = array.length - 1; i > 0; i--) {
        swap(0, i, array)
        siftDown(0, i - 1, array)
    }
    return array
}

function buildMaxHeap(array) {
    const firstParentIdx = Math.floor((array.length - 2)/2)
    for (let currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--) {
        siftDown(currentIdx, array.length - 1, array)
    }
}

function siftDown(currentIdx, endIdx, heap) {
    let childOneIdx = currentIdx * 2 + 1
    while (childOneIdx <= endIdx) {
        const childTwoIdx = currentIdx * 2 + 2 <= endIdx ? currentIdx * 2 + 2 : - 1
        let toSwap
        if (childTwoIdx !== -1 && heap[childTwoIdx] > heap[childOneIdx]) {
            toSwap = childTwoIdx
        } else {
            toSwap = childOneIdx
        }
        if (heap[toSwap] > heap[currentIdx]) {
            swap(currentIdx, toSwap, heap)
            currentIdx = toSwap
            childOneIdx = currentIdx * 2 + 1
        } else {
            return
        }
    }
}

function swap(i, j, array) {
    const tmp = array[j]
    array[j] = array[i]
    array[i] = tmp
}

exports.heapSort = heapSort;
