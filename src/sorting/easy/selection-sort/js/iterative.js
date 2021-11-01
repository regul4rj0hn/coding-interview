// O(n^2) time | O(1) space
function selectionSort(array) {
	let start = 0
	while (start < array.length - 1) {
		let smallest = start
		for (let i = start + 1; i < array.length; i++) {
			if (array[smallest] > array[i]) {
				smallest = i
			}
		}
		swap(start, smallest, array)
		start++
	}
	return array
}

function swap(i, j, array) {
	const tmp = array[j]
	array[j] = array[i]
	array[i] = tmp
}

exports.selectionSort = selectionSort;
