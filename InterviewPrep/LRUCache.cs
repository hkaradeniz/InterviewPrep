using System;
using System.Collections.Generic;

namespace InterviewPrep
{
    class LRUCache
    {
        private int capacity = 5;
        private Dictionary<int, LinkedListNode> map = new Dictionary<int, LinkedListNode>();
        private LinkedListNode head;
        private LinkedListNode tail;

        public String get(int key)
        {
            if (!map.ContainsKey(key)) return string.Empty;

            LinkedListNode item = map[key];

            if (item != head)
            {
                deleteFromLinkedList(item);
                insertLinkedListHead(item);
            }

            return item.value;
        }

        public void set(int key, String value)
        {
            // if key exists
            remove(key);

            if (map.Count >= capacity && tail != null)
                remove(tail.key);

            LinkedListNode newNode = new LinkedListNode(key, value);
            insertLinkedListHead(newNode);
            map.Add(key, newNode);
        }

        private void remove(int key)
        {
            if (!map.ContainsKey(key)) return;

            LinkedListNode item = map[key];

            if (item == null) return;

            map.Remove(key);
            deleteFromLinkedList(item);
        }

        private void deleteFromLinkedList(LinkedListNode node)
        {
            if (node == null) return;

            if (node.prev != null) node.prev.next= node.next;
            if (node.next != null) node.next.prev = node.prev;
            if (node == head) head = node.next;
            if (node == tail) tail = node.prev;
        }

        private void insertLinkedListHead(LinkedListNode node)
        {
            if (head == null)
                head = tail = node;
            else
            {
                node.next = head;
                head.prev = node;
                head = node;
            }
        }
    }

    class LinkedListNode
    {
        public int key;
        public String value;
        public LinkedListNode next;
        public LinkedListNode prev;

        public LinkedListNode(int k, String v)
        {
            this.key = k;
            this.value = v;
        }
    }
}
