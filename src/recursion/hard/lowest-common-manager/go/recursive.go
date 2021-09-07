package main

type OrgChart struct {
	Name          string
	DirectReports []*OrgChart
}

type OrgInfo struct {
	lowestCommonManager  *OrgChart
	importantReportCount int
}

// O(n) time | O(d) space
// where N is the number of people in the Org and D is the depth of the org chart
func GetLowestCommonManager(org, reportOne, reportTwo *OrgChart) *OrgChart {
	return getOrgInfo(org, reportOne, reportTwo).lowestCommonManager
}

func getOrgInfo(manager, reportOne, reportTwo *OrgChart) OrgInfo {
	reportCount := 0
	for _, directReport := range manager.DirectReports {
		info := getOrgInfo(directReport, reportOne, reportTwo)
		if info.lowestCommonManager != nil {
			return info
		}
		reportCount += info.importantReportCount
	}
	if manager == reportOne || manager == reportTwo {
		reportCount++
	}
	var lowestCommonManager *OrgChart
	if reportCount == 2 {
		lowestCommonManager = manager
	}
	return OrgInfo{
		lowestCommonManager:  lowestCommonManager,
		importantReportCount: reportCount,
	}
}
