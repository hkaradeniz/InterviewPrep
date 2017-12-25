namespace InterviewPrep.MyLinkedList
{
    class DLLNode
    {
        public int Data { get; }
        public DLLNode Prev { get; set; }
        public DLLNode Next { get; set; }

        public DLLNode(int value)
        {
            Data = value;
        }
    }

    class DoublyLinkedList
    {
        public DLLNode Head { get; set; }
        public DLLNode Tail { get; set; }

        public void InsertHead(int value)
        {
            DLLNode newNode = new DLLNode(value);

            if (Head == null)
            {
                Head = newNode;
                return;
            }

            Head.Prev = newNode;
            newNode.Next = Head;
            Head = newNode;
        }

        public void InsertTail(int value)
        {
            DLLNode newNode = new DLLNode(value);

            if (Head == null)
            {
                Head = Tail = newNode;
                return;
            }

            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
        }

        public void Clear()
        {
            Head = null;
        }
    }
}
