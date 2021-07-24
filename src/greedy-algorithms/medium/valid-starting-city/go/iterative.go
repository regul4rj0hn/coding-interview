package main

// O(n) time | O(1) space
// where N is the number of cities on the distance input array
func ValidStartingCity(distances []int, fuel []int, mpg int) int {
	cityCount := len(distances)
	milesLeft := 0
	candidateIdx := 0
	milesLeftAtCandidate := 0
	
	for cityIdx := 1; cityIdx < cityCount; cityIdx++ {
		distanceFromPreviousCity := distances[cityIdx-1]
		fuelFromPreviousCity := fuel[cityIdx-1]
		milesLeft += fuelFromPreviousCity * mpg - distanceFromPreviousCity
		
		if milesLeft < milesLeftAtCandidate {
			milesLeftAtCandidate = milesLeft
			candidateIdx = cityIdx
		}
	}
	
	return candidateIdx
}

