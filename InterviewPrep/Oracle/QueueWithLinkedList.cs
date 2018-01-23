namespace InterviewPrep.Oracle
{
    /* Implement Queue using Linked List */
    /* https://practice.geeksforgeeks.org/problems/implement-queue-using-linked-list/1 */
    /* Array implementation uses much less memory */
    /* For the Microsoft .NET CLR v4, the x86 CLR has a per-object overhead of 8 bytes, and the x64 CLR has a per-object 
     * overhead of 16 bytes. */
    class QueueWithLinkedList
    {
        LList list;

        public QueueWithLinkedList()
        {
            list = new LList();
        }

        public void Enqueue(int element)
        {
            list.AddLast(element);
        }

        public int Dequeue()
        {
            return list.DeleteFromHead();
        }

        internal class LLNode
        {
            public int Value { get; }
            public LLNode Next { get; set; }

            public LLNode(int value)
            {
                Value = value;
            }
        }


        internal class LList
        {
            public LLNode Head { get; set; }
            public LLNode Tail { get; set; }

            public void AddLast(int element)
            {
                LLNode newNode = new LLNode(element);

                if (Head == null)
                {
                    Head = Tail = newNode;
                }
                else
                {
                    Tail = Tail.Next = newNode;
                }
            }

            public int DeleteFromHead()
            {
                if (Head == null)
                    return -1;

                int value = Head.Value;

                LLNode oldHead = Head;
                Head = Head.Next;
                oldHead = null;

                return value;
            }
        }
    }
}
