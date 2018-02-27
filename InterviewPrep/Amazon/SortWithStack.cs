using System;
using System.Collections.Generic;

namespace InterviewPrep.Amazon
{
    // Sort a stack using another stack.  
    /*
        Amazon.SortWithStack ss = new Amazon.SortWithStack();
        Stack<int> input = new Stack<int>();
        input.Push(34);
        input.Push(3);
        input.Push(31);
        input.Push(98);
        input.Push(92);
        input.Push(23);
        ss.Sort(input);
     */
    class SortWithStack
    {
        public void Sort(Stack<int> originalStack)
        {
            if (originalStack == null || originalStack.Count == 0) return;

            Stack<int> tempStack = new Stack<int>();

            while (originalStack.Count >  0)
            {
                int value = originalStack.Pop();

                while (tempStack.Count > 0 && tempStack.Peek() > value)
                {
                    originalStack.Push(tempStack.Pop());
                }

                tempStack.Push(value);
            }

            PrintStack(tempStack);
        }

        private void PrintStack(Stack<int> stack)
        {
            while(stack.Count > 0)
            {
                Console.WriteLine($" { stack.Pop() } ");
            }      
        }
    }
}
