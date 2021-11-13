// O(n.log(n)) time | O(1) space
function tandemBicycle(redShirtSpeeds, blueShirtSpeeds, fastest) {
  redShirtSpeeds.sort((a, b) => a - b)
    blueShirtSpeeds.sort((a, b) => a - b)

    if (!fastest) {
        reverseArrayInPlace(redShirtSpeeds)
    }

    let totalSpeed = 0
    for (let i = 0; i < redShirtSpeeds.length; i++) {
        const rider1 = redShirtSpeeds[i]
        const rider2 = blueShirtSpeeds[blueShirtSpeeds.length - i - 1]
        totalSpeed += Math.max(rider1, rider2)
    }

    return totalSpeed
}

function reverseArrayInPlace(array) {
    let start = 0
    let end = array.length - 1
    while (start < end) {
        const tmp = array[start]
        array[start] = array[end]
        array[end]  = tmp
        start++
        end--
    }
}

exports.tandemBicycle = tandemBicycle;
