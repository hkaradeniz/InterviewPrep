using System.Collections.Generic;

namespace InterviewPrep
{
    class StackWithQueue
    {
        Queue<string> queue1 = new Queue<string>();
        Queue<string> queue2 = new Queue<string>();

        public void Push(string item)
        {
            if (queue1.Count == 0)
            {
                queue1.Enqueue(item);

                while (queue2.Count > 0)
                {
                    queue1.Enqueue(queue2.Dequeue());
                }
            }
            else
            {
                queue2.Enqueue(item);

                while (queue1.Count > 0)
                {
                    queue2.Enqueue(queue1.Dequeue());
                }
            }
        }

        public string Pop()
        {
            if (queue1.Count > 0)
            {
                return queue1.Dequeue();
            }
            else
            {
                return queue2.Dequeue();
            }
        }
    }
}
