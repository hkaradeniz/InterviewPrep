using System.Collections.Generic;

namespace InterviewPrep.Google
{
    /* The task is to design and implement methods of an LRU cache. */
    /* https://practice.geeksforgeeks.org/problems/lru-cache/1 */
    class LRUNode
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }

    class LRUCache
    {
        private const int CAPACITY = 4;
        private int CurrentLRUSize = 0;
        Dictionary<int, LRUNode> LRUDictionary = new Dictionary<int, LRUNode>();
        LinkedList<LRUNode> LRUList = new LinkedList<LRUNode>();

        public void Set(LRUNode node)
        {
            if (node == null) return; // Or throw exception

            if (LRUDictionary.ContainsKey(node.Id))
            {
                UpdateOrder(node.Id);
            }
            else
            {
                if (CurrentLRUSize < CAPACITY)
                {
                    CurrentLRUSize++;
                }
                else
                {
                    RemoveLastFromCache();
                }

                AddToCache(node);
            }
        }

        public LRUNode Get(int value)
        {
            if (LRUDictionary.ContainsKey(value))
            {
                UpdateOrder(value);
                return LRUDictionary[value];
            }

            throw new KeyNotFoundException();
        }

        private void UpdateOrder(int value)
        {
            LRUNode node = LRUDictionary[value];
            LRUList.Remove(node);
            LRUList.AddFirst(node);
        }

        private void AddToCache(LRUNode node)
        {
            LRUDictionary.Add(node.Id, node);
            LRUList.AddFirst(node);
        }

        private void RemoveLastFromCache()
        {
            LRUNode lastNode = LRUList.Last.Value;
            LRUDictionary.Remove(lastNode.Id);
            LRUList.RemoveLast();
        }
    }
}
