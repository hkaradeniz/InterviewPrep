using System.Collections.Generic;

namespace InterviewPrep.Yahoo
{
    /* Sort a stack */
    /* Given a stack, the task is to sort it */
    /* https://practice.geeksforgeeks.org/problems/sort-a-stack/1 */
    /* Solution:
        Use a temporaty stack
       1- Pop a number from the input stack
       2- If the temp stack is empty or the last value in temporary stack is smaller than the element, push the number to temp stack
       3- If the number you popped from the input stack is smaller than the last element in the temp stack, until you find
            a smaller element at the top of the temp stack, keep popping from temp stack and push it to input stack
       4- When you find the smaller element or the temp stack is empty, push the element in temp stack
       5- Repeat until input stack is 0
    */
    class SortStack
    {
        public Stack<int> Sort(Stack<int> inputStack)
        {
            if (inputStack.Count == 0) return null;

            Stack<int> tempStack = new Stack<int>();

            while(inputStack.Count > 0)
            {
                int element = inputStack.Pop();

                if (tempStack.Count == 0 || tempStack.Peek() < element)
                    tempStack.Push(element);
                else
                {
                    while (tempStack.Count != 0 && tempStack.Peek() > element)
                    {
                        int temp = tempStack.Pop();
                        inputStack.Push(temp);
                    }

                    tempStack.Push(element);
                }
            }

            while (tempStack.Count > 0)
            {
                inputStack.Push(tempStack.Pop());
            }

            return inputStack;
        }
    }
}
