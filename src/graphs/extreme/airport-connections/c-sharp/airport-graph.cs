using System;
using System.Collections.Generic;

/*
To approach the solution we start by creating a graph out of the inputs. Each airport should be a vertex in the graph, and each route should be an edge. The graph should be directed with potential cycles, since it's possible for there to be round-trip flights between airports or for some series of flights to eventually lead back to an arbitrary starting point. 

After constructing the graph, we get a list of all of the airports that are unreachable from the starting airport using depth-first search. This considering that a single unreachable airport could have connections to a bunch of other unreachable airports from the starting point, potentially making it more "valuable", since adding one connection to it would make many other airports connected / reachable.

We calculate the number of unreachable airports that are reachable from each unreachable airport (also using depth-first search), sort them in descending order according to this number (the unreachable airport count), and finally count the minimum number of connections that need to be added by iterating through this sorted list of unreachable airports, removing every unreachable airport's unreachable connections as we go through the list.

In the method comments for time and space complexity analysis, A refers to the number of Airports and R is the number of Routes
*/
public class Program {
    public class Airport {
        public string Code { get; set; }
        public bool IsReachable { get; set; }
        public List<string> Connections { get; set; }
        public List<string> UnreachableConnections { get; set; }

        public Airport (string code) {
            Code = code;
            IsReachable = true;
            Connections = new List<string>();
            UnreachableConnections = new List<string>();
        }
    }

    public static int AirportConnections(
        List<string> airports,
        List<List<string> > routes,
        string startingAirport
        ) {
        var airportGraph = CreateAirportGraph (airports, routes);
        var unreachableAirports = GetUnreachableAirports (airportGraph, airports, startingAirport);

        MarkUnreachableConnections (airportGraph, unreachableAirports);

        return GetMinimumConnections (airportGraph, unreachableAirports);
    }

    // O(a + r) time | O(a + r) space
    private static Dictionary<string, Airport> CreateAirportGraph (
        List<string> airports,
        List<List<string>> routes
    ) {
        var airportGraph = new Dictionary<string, Airport>();
        
        foreach (var code in airports) {
            airportGraph.Add (code, new Airport(code));
        }

        foreach (var route in routes) {
            var source = route[0];
            var dest = route[1];
            airportGraph[source].Connections.Add(dest);
        }

        return airportGraph;
    }

    // O(a + r) time | O(a) space
    private static List<Airport> GetUnreachableAirports (
        Dictionary<string, Airport> airportGraph,
        List<string> airports,
        string startingAirport
    ) {
        var unreachableAirports = new List<Airport>();
        var visitedAirports = new HashSet<string>();
        DepthFirstTraverseAirports (airportGraph, visitedAirports, startingAirport);

        foreach (var code in airports) {
            if (visitedAirports.Contains(code)) {
                continue;
            }
            var airport = airportGraph[code];
            airport.IsReachable = false;
            unreachableAirports.Add(airport);
        }

        return unreachableAirports;
    }

    // O(a.(a + r)) time | O(a) space
    private static void MarkUnreachableConnections (
        Dictionary<string, Airport> airportGraph,
        List<Airport> unreachableAirports
    ) {
        foreach (var airport in unreachableAirports) {
            var code = airport.Code;
            var unreachableConnections = new List<string>();
            var visitedAirports = new HashSet<string>();
            DepthFirstAddUnreachableConnections (airportGraph, unreachableConnections, visitedAirports, code);
            airport.UnreachableConnections = unreachableConnections;
        }
    }

    // O(a.log(a) + a + r) time | O(1) space
    private static int GetMinimumConnections (
        Dictionary<string, Airport> airportGraph,
        List<Airport> unreachableAirports
    ) {
        unreachableAirports.Sort((source, dest) => dest.UnreachableConnections.Count - source.UnreachableConnections.Count);

        var connectionsCount = 0;
        foreach (var airport in unreachableAirports) {
            if (airport.IsReachable) {
                continue;
            }
            connectionsCount++;

            foreach (var connection in airport.UnreachableConnections) {
                airportGraph[connection].IsReachable = true;
            }
        }
        return connectionsCount;
    }

    private static void DepthFirstTraverseAirports (
        Dictionary<string, Airport> airportGraph,
        HashSet<string> visitedAirports,
        string airportCode
    ) {
        if (visitedAirports.Contains(airportCode)) {
            return;
        }

        visitedAirports.Add(airportCode);
        var connections = airportGraph[airportCode].Connections;

        foreach (var code in connections) {
            DepthFirstTraverseAirports (airportGraph, visitedAirports, code);
        }
    }

    private static void DepthFirstAddUnreachableConnections (
        Dictionary<string, Airport> airportGraph,
        List<string> unreachableConnections,
        HashSet<string> visitedAirports,
        string airportCode
    ) {
        if (airportGraph[airportCode].IsReachable) {
            return;
        }
        if (visitedAirports.Contains(airportCode)) {
            return;
        }

        visitedAirports.Add(airportCode);
        unreachableConnections.Add(airportCode);
        var connections = airportGraph[airportCode].Connections;

        foreach (var code in connections) {
            DepthFirstAddUnreachableConnections (airportGraph, unreachableConnections, visitedAirports, code);
        }
    }
}
