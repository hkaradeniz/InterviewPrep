namespace InterviewPrep.MyLinkedList
{
    class MyLinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public void ClearLinkedList()
        {
            Head = null;
        }

        public Node First()
        {
            return Head;
        }

        public void AddLast(int Value)
        {
            Node newNode = new Node(Value);

            if (Head == null)
            {
                Tail = newNode;
                Head = Tail;
            }
            else
            {
                Tail = Tail.Next = newNode;
            }
        }

        public void AddFirst(int value)
        {
            Node newNode = new Node(value);

            if (Head == null)
            {
                Tail = newNode;
                Head = Tail;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
        }

        public Node FindNode(int value)
        {
            Node current = Head;

            while (current != null)
            {
                if (current.Value == value)
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        public void DisplayAll()
        {
            Node current = Head;

            while (current != null)
            {
                current.DisplayNode();
                current = current.Next;
            }
        }

        public void Remove(int value)
        {
            Node current = Head;
            Node previous = current;

            while (current != null)
            {
                if (current.Value == value)
                {
                    //// Found... Delete it...

                    if (current == Head)
                    {
                        Head = Head.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }

                    break;
                }

                previous = current;
                current = current.Next;
            }
        }
    }
}
