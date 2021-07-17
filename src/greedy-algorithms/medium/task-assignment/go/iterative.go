package main

import (
	"sort"
)

func TaskAssignment(k int, tasks []int) [][]int {
	pairedTasks := make([][]int, 0)
	taskDurationIndex := getTaskDurationToIndex(tasks)
	
	sort.Slice(tasks, func(i, j int) bool {
		return tasks[i] < tasks[j]
	})
	
	var task1Index, task2Index int
	for i := 0; i < k; i++ {
		task1Duration := tasks[i]
		indicesWithTask1Duration := taskDurationIndex[task1Duration]
		task1Index, taskDurationIndex[task1Duration] = 
			indicesWithTask1Duration[len(indicesWithTask1Duration)-1],
			indicesWithTask1Duration[:len(indicesWithTask1Duration)-1]
		
		task2SortedIndex := len(tasks) - 1 - i
		task2Duration := tasks[task2SortedIndex]
		indicesWithTask2Duration := taskDurationIndex[task2Duration]
		task2Index, taskDurationIndex[task2Duration] = 
			indicesWithTask2Duration[len(indicesWithTask2Duration)-1],
			indicesWithTask2Duration[:len(indicesWithTask2Duration)-1]
		
		pairedTasks = append(pairedTasks, []int{task1Index, task2Index})
	}
	
	return pairedTasks
}

func getTaskDurationToIndex(tasks []int) map[int][]int {
	taskDurationIndex := map[int][]int{}
	
	for i := range tasks {
		taskDuration := tasks[i]
		taskDurationIndex[taskDuration] = append(taskDurationIndex[taskDuration], i)
	}
	
	return taskDurationIndex
}
