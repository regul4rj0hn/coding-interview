using System;
using System.Collections.Generic;

/*
Given a random subtree in the organizational chart, the manager at the root of that subtree is always common to any two reports in the subtree. Given that, the lowest common manager to two reports in an organizational chart is the root of the lowest subtree containing those two reports. If we find that lowest subtree we find the lowest common manager.

To find the lowest subtree containing both of the input reports, we recursively traverse the org chart keeping track of the number of those reports contained in each subtree as well as the lowest common manager in each subtree.
Some subtrees might contain neither of the two reports, some might contain one of them, and others might contain both; the first to contain both should return the lowest common manager for all of the subtrees above it that contain it, including the entire organizational chart.

Time : O(n) - Where N is the number of people in the Organizational Chart
Space: O(d) - Where D is the depth (height) of the Organizational Chart (for the frames on the recursive call stack)
*/
public class Program {
    public static OrgChart GetLowestCommonManager(OrgChart topManager, OrgChart reportOne, OrgChart reportTwo) {
        return GetOrgInfo (topManager, reportOne, reportTwo).LowestCommonManager;
    }

    private static OrgInfo GetOrgInfo (OrgChart manager, OrgChart reportOne, OrgChart reportTwo) {
        var countReports = 0;
        foreach (var directReport in manager.directReports) {
            var info = GetOrgInfo (directReport, reportOne, reportTwo);

            if (info.LowestCommonManager != null) {
                return info;
            }
            countReports += info.ImportantReportCount;
        }

        if (manager == reportOne || manager == reportTwo) {
            countReports++;
        }

        var commonManager = countReports == 2 ? manager : null;
        var newInfo = new OrgInfo (commonManager, countReports);

        return newInfo;
    }

    private class OrgInfo {
        public OrgChart LowestCommonManager { get; set; }
        public int ImportantReportCount { get; set; }

        public OrgInfo(OrgChart manager, int reports) {
            LowestCommonManager = manager;
            ImportantReportCount = reports;
        }
    }

    public class OrgChart {
        public char name;
        public List<OrgChart> directReports;

        public OrgChart(char name) {
            this.name = name;
            this.directReports = new List<OrgChart>();
        }

        public void addDirectReports(OrgChart[] directReports) {
            foreach (OrgChart directReport in directReports) {
                this.directReports.Add(directReport);
            }
        }
    }
}
