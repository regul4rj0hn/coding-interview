package main

// O((2n)!/(n!((n+1)!))) time | O((2n)!/(n!((n+1)!))) space
// where N is the input number of tags needed
func GenerateDivTags(numberOfTags int) []string {
	matchedDivs := []string{}
	generateDivsFromPrefix(numberOfTags, numberOfTags, "", &matchedDivs)
	return matchedDivs
}

func generateDivsFromPrefix(openingTags, closingTags int, prefix string, result *[]string) {
	if openingTags > 0 {
		newPrefix := prefix + "<div>"
		generateDivsFromPrefix(openingTags-1, closingTags, newPrefix, result)
	}
	if openingTags < closingTags {
		newPrefix := prefix + "</div>"
		generateDivsFromPrefix(openingTags, closingTags-1, newPrefix, result)
	}
	if closingTags == 0 {
		*result = append(*result, prefix)
	}
}
