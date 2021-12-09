// O(n.log(n)) time | O(n) space
function taskAssignment(k, tasks) {
    const pairedTasks = []
    const taskDurationToIndices = getTaskDurationToIndices(tasks)

    const sortedTasks = [...tasks].sort((a, b) => a - b)
    for (let idx = 0; idx < k; idx++) {
        const task1Duration = sortedTasks[idx]
        const indicesWithTask1Duration = taskDurationToIndices[task1Duration]
        const task1Index = indicesWithTask1Duration.pop()

        const task2SortedIndex = tasks.length - 1 - idx
        const task2Duration = sortedTasks[task2SortedIndex]
        const indicesWithTask2Duration = taskDurationToIndices[task2Duration]
        const task2Index = indicesWithTask2Duration.pop()

        pairedTasks.push([task1Index, task2Index])
    }

    return pairedTasks
}

function getTaskDurationToIndices(tasks) {
    const taskDurationToIndices = {}
    for (let idx = 0; idx < tasks.length; idx++) {
        const taskDuration = tasks[idx]
        if (taskDuration in taskDurationToIndices) {
            taskDurationToIndices[taskDuration].push(idx)
        } else {
            taskDurationToIndices[taskDuration] = [idx]
        }
    }
    return taskDurationToIndices
}

exports.taskAssignment = taskAssignment;
