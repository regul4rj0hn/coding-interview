// O(n.log(n)) time | O(1) space
function minimumWaitingTime(queries) {
    queries.sort((a, b) => a - b)

    let totalWaitingTime = 0
    for (let i = 0; i < queries.length; i++) {
        const duration = queries[i]
        const queriesLeft = queries.length - (i + 1)
        totalWaitingTime += duration * queriesLeft
    }

    return totalWaitingTime
}

exports.minimumWaitingTime = minimumWaitingTime;
