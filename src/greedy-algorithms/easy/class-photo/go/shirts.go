package main

import (
	"sort"
)

const (
	BlueShirt = "BLUE"
	RedShirt  = "RED"
)

// O(n.log(n)) time | O(1) space
// where N is the number of students / shirts
func ClassPhotos(redShirtHeights []int, blueShirtHeights []int) bool {
	sort.Slice(redShirtHeights, func(i, j int) bool {
		return redShirtHeights[i] > redShirtHeights[j]
	})
	sort.Slice(blueShirtHeights, func(i, j int) bool {
		return blueShirtHeights[i] > blueShirtHeights[j]
	})

	firstRowShirtColor := BlueShirt
	if redShirtHeights[0] < blueShirtHeights[0] {
		firstRowShirtColor = RedShirt
	}

	for i := range redShirtHeights {
		redShirtHeight := redShirtHeights[i]
		blueShirtHeight := blueShirtHeights[i]

		if firstRowShirtColor == RedShirt {
			if redShirtHeight >= blueShirtHeight {
				return false
			}
		} else {
			if blueShirtHeight >= redShirtHeight {
				return false
			}
		}
	}

	return true
}
