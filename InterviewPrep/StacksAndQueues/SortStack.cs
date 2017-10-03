using System.Collections.Generic;

namespace InterviewPrep.StacksAndQueues
{
    /*?
   Cracking the Coding Interview, 6th Edition
   Three in One: Describe how you could use a single array to implement three stacks.

    Sort Stack: Write a program to sort a stack such that the smallest items are on the top. You can use
    an additional temporary stack, but you may not copy the elements into any other data structure
    (such as an array). The stack supports the following operations: push, pop, peek, and is Empty
    
        Imagine we have the following stacks, where s2 is"sorted" and sl is not:
        S1      S2
                12
        5       8
        10      3
        7       1

        When we pop 5 from s 1, we need to find the right place in s2 to insert this number. In this case, the correct
        place is on s2 just above 3. How do we get it there? We can do this by popping 5 from sl and holding it
        in a temporary variable. Then, we move 12 and 8 over to s 1 (by popping them from s2 and pushing them
        onto sl) and then push 5 onto s2.
   */

    class SortStack
    {
        public Stack<int> Sort(Stack<int> stack)
        {
            Stack<int> buffer = new Stack<int>();

            /* while(!stack.IsEmpty()) */
            while (stack.Count > 0)
            {
                int temp = stack.Pop();

                while (buffer.Count > 0 && buffer.Peek() > temp)
                {
                    stack.Push(buffer.Pop());
                }

                buffer.Push(temp);
            }

            return buffer;
        }
    }
}
