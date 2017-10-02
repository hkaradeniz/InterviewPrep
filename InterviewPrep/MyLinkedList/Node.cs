using System;

namespace InterviewPrep.MyLinkedList
{
    public class Node
    {
        public Node Next { get; set; }
        public int Value { get; set; }

        public Node(int val)
        {
            Value = val;
        }

        public void DisplayNode()
        {
            Console.WriteLine($"Node Value: {Value}");
        }
    }
}
