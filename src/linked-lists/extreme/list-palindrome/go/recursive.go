package main

type LinkedList struct {
	Value int
	Next  *LinkedList
}

type LinkedListInfo struct {
	areOuterNodesEqual bool
	leftNodeToCompare  *LinkedList
}

// O(n) time | O(n) space
// where N is the number of nodes on the linked list
func LinkedListPalindrome(head *LinkedList) bool {
	result := isPalindrome(head, head)
	return result.areOuterNodesEqual
}

func isPalindrome(leftNode, rightNode *LinkedList) LinkedListInfo {
	if rightNode == nil {
		return LinkedListInfo{true, leftNode}
	}

	results := isPalindrome(leftNode, rightNode.Next)
	leftNodeToCompare := results.leftNodeToCompare
	areOuterNodesEqual := results.areOuterNodesEqual

	isEqual := areOuterNodesEqual && leftNodeToCompare.Value == rightNode.Value
	nextLeftNodeToCompare := leftNodeToCompare.Next

	return LinkedListInfo{isEqual, nextLeftNodeToCompare}
}
