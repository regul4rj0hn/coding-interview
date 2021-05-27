package main

type LRUCache struct {
	currentSize int
	index       map[string]*DoublyLinkedListNode
	maxSize     int
	mostRecent  *DoublyLinkedList
}

// LRU Cache Methods
func NewLRUCache(size int) *LRUCache {
	lru := &LRUCache{
		currentSize: 0,
		index:       map[string]*DoublyLinkedListNode{},
		maxSize:     size,
		mostRecent:  &DoublyLinkedList{},
	}
	if lru.maxSize < 1 {
		lru.maxSize = 1
	}
	return lru
}

// O(1) time | O(1) space
func (cache *LRUCache) InsertKeyValuePair(key string, value int) {
	if _, found := cache.index[key]; !found {
		if cache.currentSize == cache.maxSize {
			cache.evictLeastRecent()
		} else {
			cache.currentSize += 1
		}
		cache.index[key] = &DoublyLinkedListNode{
			key:   key,
			value: value,
		}
	} else {
		cache.replaceKey(key, value)
	}
	cache.updateMostRecent(cache.index[key])
}

// The second return value indicates whether or not the key was found in the cache.
// O(1) time | O(1) space
func (cache *LRUCache) GetValueFromKey(key string) (int, bool) {
	node, found := cache.index[key]
	if !found {
		return 0, false
	}
	cache.updateMostRecent(node)
	return node.value, true
}

// The second return value is false if the cache is empty.
// O(1) time | O(1) space
func (cache *LRUCache) GetMostRecentKey() (string, bool) {
	if cache.mostRecent.head == nil {
		return "", false
	}
	return cache.mostRecent.head.key, true
}

// LRU Cache Helper Methods
func (cache *LRUCache) evictLeastRecent() {
	key := cache.mostRecent.tail.key
	cache.mostRecent.removeTail()
	delete(cache.index, key)
}

func (cache *LRUCache) updateMostRecent(node *DoublyLinkedListNode) {
	cache.mostRecent.setHead(node)
}

func (cache *LRUCache) replaceKey(key string, value int) {
	node, found := cache.index[key]
	if !found {
		panic("The key is not in the cache")
	}
	node.value = value
}
