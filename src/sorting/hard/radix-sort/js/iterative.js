// O(d.(n + b)) time | O(n + b) space
// where N is the lenght of the input array, D is the max number of digits, B is the base of the number system
function radixSort(array) {
    if (array.length === 0) {
        return array
    }

    const max = Math.max(...array)

    let digit = 0
    while (max / 10 ** digit > 0) {
        countingSort(array, digit)
        digit++
    }
    return array
}

function countingSort(array, digit) {
    const sortedArray = new Array(array.length).fill(0)
    const countArray = new Array(10).fill(0)

    const digitColumn = 10 ** digit
    for (const num of array) {
        const countIndex = Math.floor(num / digitColumn) % 10
        countArray[countIndex]++
    }

    for (let i = 1; i < 10; i++) {
        countArray[i] += countArray[i - 1]
    }

    for (let i = array.length - 1; i > -1; i--) {
        const countIndex = Math.floor(array[i] / digitColumn) % 10
        countArray[countIndex]--
        const sortedIndex = countArray[countIndex]
        sortedArray[sortedIndex] = array[i]
    }

    for (let i = 0; i < array.length; i++) {
        array[i] = sortedArray[i]
    }
}

exports.radixSort = radixSort;
