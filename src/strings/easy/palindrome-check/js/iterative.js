// O(n) time | O(1) space
// where N is the length of the string
function isPalindrome(string) {
    let leftIdx = 0
    let rightIdx = string.length - 1
    while (leftIdx < rightIdx) {
        if (string[leftIdx] !== string[rightIdx]) {
            return false
        }
        leftIdx++
        rightIdx--
    }
    return true
}

exports.isPalindrome = isPalindrome;
