using System;
using System.Collections.Generic;

/*
Go through all possible combinations of valid IP-address parts by generating a valid first part, then generating all valid second parts given the first part,
then finally all valid third and fourth parts given first and second parts. We can generate the parts just by placing the dots on different positions of the 
string, and checking whether it makes a valid octect or not. The placement of the periods always depend on the period before it.
When a valid set of four parts is found, then simply combine/join them together with '.', add the resulting IP address to the output list, and backtrack.
After going through all possible parts and storing valid IP addresses, all of the IP addresses that can be formed from the input string will be found.

Time : O(1) - The running time of this solution does not depend on the size of the input string. Since we are creating IPs we know before hand that the
maximum length for a valid input string will be 12 chars which can be represented with 32 bits, so we are dealing with O(2^32) which is constant.

Space: O(1) - Same as with the space, we can only generate a list that has at most 2^32 IP addresses (which can't never really happen with a single input)
*/
public class Program {
    public List<string> ValidIPAddresses (string str) {
        var ips = new List<string> ();

        for (int i = 1; i < Math.Min (str.Length, 4); i++) {
            var currentIp = new string[4];

            currentIp[0] = str.Substring (0, i);
            if (!IsPartValid (currentIp[0])) {
                continue;
            }

            for (int j = i + 1; j < i + Math.Min (str.Length - i, 4); j++) {
                currentIp[1] = str.Substring (i, j - i);
                if (!IsPartValid (currentIp[1])) {
                    continue;
                }

                for (int k = j + 1; k < j + Math.Min (str.Length - j, 4); k++) {
                    currentIp[2] = str.Substring (j, k - j);
                    currentIp[3] = str.Substring (k);
                    if (IsPartValid (currentIp[2]) && IsPartValid (currentIp[3])) {
                        ips.Add (string.Join ('.', currentIp));
                    }
                }
            }
        }

        return ips;
    }

    // Check if the octect in string form is a valid IP (0 < IP < 256) with no leading zeros
    private bool IsPartValid (string str) {
        var intString = Int32.Parse (str);
        return intString > 255 ? false : str.Length == intString.ToString ().Length;
    }
}