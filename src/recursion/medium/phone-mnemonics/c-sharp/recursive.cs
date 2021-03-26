using System.Collections.Generic;
using System;

/*
Create a key-value map where the digit is the key and value are the letters associated to it (or in the case of 0 and 1, a single digit)
Use recursion and the dictionary above to generate all possible characters one digit at a time (with an index to keep track of the current position), and store the intermediate result in an array. Then call recursively with the next position.
Once that we've reached the last digit in the phone number (comparing with the phone length), we can add the currently generated string mnemonic to our final output list.
*/
public class Program {
    private static Dictionary<char, string[]> DigitLetters = new Dictionary<char, string[]> {
        { '0', new string[] {"0"} },
        { '1', new string[] {"1"} },
        { '2', new string[] {"a", "b", "c"} },
        { '3', new string[] {"d", "e", "f"} },
        { '4', new string[] {"g", "h", "i"} },
        { '5', new string[] {"j", "k", "l"} },
        { '6', new string[] {"m", "n", "o"} },
        { '7', new string[] {"p", "q", "r", "s"} },
        { '8', new string[] {"t", "u", "v"} },
        { '9', new string[] {"w", "x", "y", "z"} }
    };

    // O(4^n.n) time | O(4^n.n) space - where N is the length of the phone number
    public List<string> PhoneNumberMnemonics (string phone) {
        var currentMnemonic = new string[phone.Length];
        Array.Fill (currentMnemonic, "0");

        var foundMnemonics = new List<string> ();
        GetPhoneNumberMnemonics (0, phone, currentMnemonic, foundMnemonics);

        return foundMnemonics;
    }

    private void GetPhoneNumberMnemonics (
        int idx,
        string phone,
        string[] current,
        List<string> mnemonics
    ) {
        if (idx == phone.Length) {
            var mnemonic = String.Join ("", current);
            mnemonics.Add (mnemonic);
        }
        else {
            var digit = phone[idx];
            var letters = DigitLetters[digit];

            foreach (var letter in letters) {
                current[idx] = letter;
                GetPhoneNumberMnemonics (idx + 1, phone, current, mnemonics);
            }
        }
    }
}
